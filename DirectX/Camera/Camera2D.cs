using SlimDX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Graphics.DirectX.Camera
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// 2D描画用のカメラ
    /// </summary>
    public class Camera2D : ICamera2D
    {
        #region Public properties

        #region ICamera

        public Size ClipSize
        {
            get;
            set;
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public Camera2D() :
            this(Size.Empty)
        {

        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="clipSize">クリップ面のサイズ</param>
        public Camera2D(Size clipSize)
        {
            ClipSize = clipSize;
        }

        #endregion

        #region Public methods

        #region ICamera

        public void Update(D3D.Device device)
        {
            UpdateView(device);
            UpdateProjection(device);
        }

        #endregion

        #endregion

        #region Private methods

        /// <summary>
        /// ビュー行列を更新する
        /// </summary>
        private void UpdateView(D3D.Device device)
        {
            // 画面の左上を原点とし、右方向にx軸、下方向にy軸が来るようにしている
            var view = Matrix.Identity;
            view.M22 = -1;
            view.M41 = -ClipSize.Width / 2.0f;
            view.M42 =  ClipSize.Height / 2.0f;

            device.SetTransform(D3D.TransformState.View, view);
        }

        /// <summary>
        /// 射影行列を更新する
        /// </summary>
        private void UpdateProjection(D3D.Device device)
        {
            var projection = Matrix.OrthoLH(ClipSize.Width, ClipSize.Height, -.1f, 1f);
            device.SetTransform(D3D.TransformState.Projection, projection);
        }

        #endregion
    }
}