using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapViewer.Renderer;
using MapViewer.Geometory;
using MapViewer.Provider;

namespace MapViewer.View
{
    /// <summary>
    /// <see cref="Graphics"/>を使用して地図を描画するコントロール
    /// </summary>
    public partial class MapControl : UserControl, IOpenable
    {
        #region Private fields

        /// <summary>
        /// ポリゴンのレンダラ
        /// </summary>
        private IRenderer<Polygon> _renderer;

        /// <summary>
        /// 地図を構成するポリゴン
        /// </summary>
        private IList<Polygon> _polygons;

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public MapControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// プロバイダからポリゴンを作成する
        /// </summary>
        /// <param name="provider">ポリゴンのプロバイダ</param>
        public void Open(IProvider provider)
        {
            // 作成中はカーソルを待機状態にする
            Cursor = Cursors.WaitCursor;

            // ファイルから地図を構成するポリゴンを作成する
            Task.Factory.StartNew(() =>
            {
                _polygons = provider.Provide(ClientSize);
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
            if (_polygons.Count > 0)
            {
                _renderer.Render(e.Graphics, _polygons);
            }
            base.OnPaint(e);
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
            _polygons = new List<Polygon>();
            _renderer = new GraphicsRenderer();

            //画面がちらつかないようにする
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion

        private void RequestRepaint()
        {
            // 異なる地図を描画する場合は以前の描画をクリアしておく
            CreateGraphics().Clear(BackColor);
            Invalidate();
        }

        #endregion
    }
}
