using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Graphics.DirectX.Camera
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// 2D描画用のカメラインタフェース
    /// </summary>
    public interface ICamera2D
    {
        #region Public properties

        /// <summary>
        /// クリップ面のサイズ
        /// </summary>
        Size ClipSize
        {
            get;
            set;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// カメラ座標系を更新する
        /// </summary>
        /// <param name="device">D3Dデバイス</param>
        void Update(D3D.Device device);

        #endregion
    }
}
