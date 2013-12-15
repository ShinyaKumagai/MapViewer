using MapViewer.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapViewer
{
    public partial class D3DMapViewForm : Form
    {
        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public D3DMapViewForm()
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
                mapControl.Open(provider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 地図の更新ボタンが押下されたときに呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickReflesh(object sender, EventArgs e)
        {
            mapControl.Invalidate();
        }

        #endregion
    }
}
