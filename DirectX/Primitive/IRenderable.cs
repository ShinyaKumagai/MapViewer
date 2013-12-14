using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics.DirectX.Primitive
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// プリミティブの描画インターフェース
    /// </summary>
    public interface IRenderable
    {
        #region Public methods

        /// <summary>
        /// プリミティブを描画する
        /// </summary>
        /// <param name="device">D3Dデバイス</param>
        void Render(D3D.Device device);

        #endregion
    }
}
