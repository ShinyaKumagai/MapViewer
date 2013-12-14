using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics.DirectX.VertexBuffer
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// 頂点バッファを操作するためのインターフェース
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDynamicVertexBuffer<T> : IDisposable
        where T : struct
    {
        #region Public properties

        /// <summary>
        /// バッファ内の頂点数
        /// </summary>
        int VertexCount
        {
            get;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// 描画対象の頂点バッファに指定する
        /// </summary>
        /// <param name="device"></param>
        void SetStreamSource(D3D.Device device);

        /// <summary>
        /// 頂点バッファに変更をコミットする
        /// </summary>
        void Commit();

        /// <summary>
        /// バッファに頂点を追加する
        /// </summary>
        /// <param name="vertex"></param>
        void Add(T vertex);

        /// <summary>
        /// バッファに頂点配列を追加する
        /// </summary>
        /// <param name="vertices">頂点配列</param>
        void Add(T[] vertices);

        /// <summary>
        /// バッファの頂点をすべて削除する
        /// </summary>
        void Clear();

        #endregion
    }
}
