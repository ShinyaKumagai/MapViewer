using MapViewer.Converter;
using MapViewer.Geometory;
using MapViewer.Loader;
using MapViewer.Provider;
using MapViewer.Renderer;
using MapViewer.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        /// <see cref="Graphics"/>を使用して地図を描画するコントロール
        /// </summary>
        private MapControl _mapControl;

        #endregion

        #region Constructor

        public MapViewForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

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

            string filepath = openFileDialog.FileName;
            try
            {
                var provider = new KmlProvider(filepath);
                _mapControl.Open(provider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// フォームがロードされたときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            // クライアント領域のサイズを設定する
            SizeFromClientSize(new Size(1000, 1000));

            // デフォルトではグラフィックスを使用した地図を描画する
            _mapControl = new MapControl()
            {
                Size = ClientSize
            };
            Controls.Add(_mapControl);

            //画面がちらつかないようにする
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        /// <summary>
        /// 地図の更新ボタンが押下されたときに呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCLickReflesh(object sender, EventArgs e)
        {
            _mapControl.Invalidate();
        }

        #endregion
    }
}
