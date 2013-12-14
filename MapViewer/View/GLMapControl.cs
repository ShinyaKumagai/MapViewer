using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using MapViewer.Provider;
using System.Threading.Tasks;
using MapViewer.Renderer;
using MapViewer.Geometory;
using OpenTK.Graphics.OpenGL;
using MapViewer.Converter;
using MapViewer.Provider.OpenGL;
using MapViewer.Geometory.OpenGL;
using MapViewer.Renderer.OpenGL;
using Graphics.OpenGL.Primitive;
using Graphics.OpenGL.Vertex;


namespace MapViewer.View.OpenGL
{
    /// <summary>
    /// OpenGLを使用して地図を描画するコントロール
    /// </summary>

    public partial class GLMapControl : GLControl, IOpenable, IClosable
    {
        #region Public properties

        /// <summary>
        /// 地図を構成するポリゴン
        /// </summary>
        public IList<LinePolygon> LinePolygons
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public GLMapControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        public void Open(IProvider<Polygon> provider)
        {
            // ロード中はカーソルを待機状態にする
            Cursor = Cursors.WaitCursor;

            // ファイルからGL用のラインポリゴンを作成する
            var polygons = new GLPolygonProvider(provider).Provide(ClientSize);
            CreateLinePolygons(polygons);

            // 終了時にカーソルを戻す
            Cursor = Cursors.Default;
            // コントロールを再描画する
            Invalidate();
        }

        #endregion

        #region IClosable

        public void Close()
        {
            if (LinePolygons == null)
            {
                return;
            }

            foreach (var polyline in LinePolygons)
            {
                polyline.Delete();
            }
        }

        #endregion

        #region Private methods

        #region Events

        /// <summary>
        /// コントロールが読み込まれたときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            LinePolygons = new List<LinePolygon>();

            //画面がちらつかないようにする
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion

        private void CreateLinePolygons(IList<GLPolygon> polygons)
        {
            LinePolygons = new List<LinePolygon>(polygons.Count);

            // 作成したポリゴンをO頂点配列に変換する
            foreach (var polygon in polygons)
            {
                var vertices = polygon.Select(p =>
                    {
                        return new VertexPosition()
                        {
                            Position = new Vector2(p.X, p.Y),
                        };
                    });
                // 頂点配列からポリゴンラインのVBOを作成する
                var linePolygon = new LinePolygon();
                linePolygon.Generate(vertices.ToArray());

                LinePolygons.Add(linePolygon);
            }
        }

        #endregion
    }
}
