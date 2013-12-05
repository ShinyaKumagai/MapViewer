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

namespace MapViewer.View
{
    /// <summary>
    /// OpenGLを使用して地図を描画するコントロール
    /// </summary>

    public partial class GLMapControl : GLControl, IOpenable
    {
        #region Private fields

        /// <summary>
        /// ポリゴンのレンダラ
        /// </summary>
        private IRenderer<GLPolygon> _renderer;

        /// <summary>
        /// 地図を構成するポリゴン
        /// </summary>
        private IList<GLPolygon> _polygons;

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

        public void Open(IProvider provider)
        {
            Cursor = Cursors.WaitCursor;
            // ファイルから地図を構成するポリゴンを作成する
            Task.Factory.StartNew(() =>
            {
                var srcPolygons = provider.Provide(ClientSize);
                _polygons = new VectorConverter().Convert(srcPolygons);
            })
            .ContinueWith((t) =>
            {
                RequestRepaint();
                // 終了時にカーソルを戻す
                Cursor = Cursors.Default;
            },
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// 再描画する際に呼ばれる処理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_polygons != null || _polygons.Count > 0)
            {
                _renderer.Render(e.Graphics, _polygons);
            }
            base.OnPaint(e);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// コントロールが読み込まれたときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            _polygons = new List<GLPolygon>();
            _renderer = new OpenGLRenderer();

            //画面がちらつかないようにする
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void RequestRepaint()
        {
            // 異なる地図を描画する場合は以前の描画をクリアしておく
            GL.ClearColor(BackColor);
            Invalidate();
        }

        #endregion
    }
}
