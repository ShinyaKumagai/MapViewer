using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics.DirectX.Primitive
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// Direct3Dで扱うプリミティブのインターフェース
    /// </summary>
    /// <typeparam name="T">プリミティブの頂点</typeparam>
    public interface IPrimitive<T> : IRenderable, IDisposable
        where T : struct
    {
        #region Public methods

        /// <summary>
        /// 頂点バッファ作成する
        /// </summary>
        /// <param name="device">D3Dデバイス</param>
        void CreateVertexBuffer(D3D.Device device, T[] vertices);

        #endregion
    }
}
