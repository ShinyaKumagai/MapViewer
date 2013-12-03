using MapViewer.Converter;
using MapViewer.Loader;
using MapViewer.Renderer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapViewer
{
    /// <summary>
    /// 地図を表示するためのフォーム
    /// </summary>
    public partial class MapViewForm : Form
    {
        #region Private fields

        /// <summary>
        /// 描画するポリゴン
        /// </summary>
        private IList<Geometory.Polygon> _drawPolygons;

        /// <summary>
        /// ポリゴンのレンダラ
        /// </summary>
        private IRenderer _renderer;

        #endregion

        #region Constructor

        public MapViewForm()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// メニューの「ファイルを開く」をクリックしたときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickOpenFile(object sender, EventArgs e)
        {
            // KMLファイルを読み込むための設定
            openFileDialog.Title = "KMLファイルを選択してください";
            openFileDialog.FileName = "map.kml";
            openFileDialog.Filter = "KMLファイル(*.kml)|*.kml";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            IList<Geometory.Polygon> polygons = null;

            Cursor = Cursors.WaitCursor;
            
            Task.Factory.StartNew(() =>
                {
                    // ファイルからポリゴンを作成する
                    return new KmlLoader().Load(openFileDialog.FileName);
                })
            .ContinueWith((t) =>
                {
                    // 読み込んだ地図を座標変換する
                    var converter = new PolygonConverter()
                    {
                        Polygons = t.Result,
                        DisplaySize = Math.Min(ClientSize.Width, ClientSize.Height),
                    };
                    return polygons = converter.Convert();
                })
            .ContinueWith((t) =>
                {
                    _drawPolygons = t.Result;
                    Console.WriteLine("Finished {0} polygons", polygons.Count);
                    // 異なる地図を描画する場合は以前の描画をクリアしておく
                    CreateGraphics().Clear(BackColor);
                    Invalidate();
                    // 終了時にカーソルを戻す
                    Cursor = Cursors.Default;
                }, 
                TaskScheduler.FromCurrentSynchronizationContext()
            );
        }

        /// <summary>
        /// フォームがロードされたときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            _drawPolygons = new List<Geometory.Polygon>();
            _renderer = new GraphicsRenderer();

            // クライアント領域のサイズを設定する
            SizeFromClientSize(new Size(1000, 1000));

            //画面がちらつかないようにする
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
       
        /// <summary>
		/// 画面を描画するときに呼ばれる
		/// </summary>
		/// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_drawPolygons.Count > 0)
            {
                _renderer.Render(e.Graphics,_drawPolygons);
            }
            base.OnPaint(e);
        }
    }
}
