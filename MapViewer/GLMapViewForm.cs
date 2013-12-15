using Graphics.OpenGL.Camera;
using MapViewer.Provider;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapViewer
{
    public partial class GLMapViewForm : Form
    {
        #region Private fields

        /// <summary>
        /// 2D表示用のカメラ
        /// </summary>
        private Camera2D _camera;

        #endregion

        #region Constructor

        public GLMapViewForm()
        {
            InitializeComponent();

            _camera = new Camera2D();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// フォームがロードされたときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            glMapControl.MakeCurrent();

            // 背景は白色で塗りつぶす
            GL.ClearColor(Color.White);
        }

        /// <summary>
        /// スクリーンのサイズが変わるときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResize(object sender, EventArgs e)
        {
            // コントロールのサイズが変わった場合はクリップ面に反映させる
            // クリップ面はコントロールの描画領域と同じサイズ
            var mapControlSize = glMapControl.ClientSize;
            _camera.ClipSize = new Vector2(mapControlSize.Width, mapControlSize.Height);
            GL.Viewport(glMapControl.ClientRectangle);
        }

        /// <summary>
        /// 地図コントロールを再描画する際に呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaintMap(object sender, PaintEventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();

            GL.Clear(ClearBufferMask.ColorBufferBit);

            // 射影行列を更新する
            _camera.Update();

            // 行列をジオメトリ描画用に変更する
            GL.MatrixMode(MatrixMode.Modelview);
            // 線は赤色で描画する
            GL.Color4(Color.Red);
            GL.PushMatrix();
            {
                foreach (var polyline in glMapControl.LinePolygons)
                {
                    polyline.Render();
                }
            }
            GL.PopMatrix();

            // 画面に反映させる。
            glMapControl.SwapBuffers();

            Console.WriteLine("elapsedTime : {0}", stopwatch.Elapsed);
        }

        /// <summary>
        /// メニューの「ファイルを開く」をクリックしたときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickFileOpen(object sender, EventArgs e)
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
                glMapControl.Open(provider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// フォームを閉じたときに呼ばれる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            glMapControl.Close();
        }

        /// <summary>
        /// <see cref="Graphics"/>版の地図フォームを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenOtherMap(object sender, EventArgs e)
        {
            new MapViewForm().Show();
        }

        /// <summary>
        /// Direct3D版の地図フォームを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenDirect3DMap(object sender, EventArgs e)
        {
            new D3DMapViewForm().Show();
        }

        /// <summary>
        /// 地図の更新ボタンが押下されたときに呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickReflesh(object sender, EventArgs e)
        {
            glMapControl.Invalidate();
        }

        #endregion
    }
}
