using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics.DirectX.Vertex
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// 頂点宣言のコンテナ
    /// </summary>
    /// <remarks>
    /// <see cref="DynamicVertexBuffer"/>を使用して描画する場合は<seealso cref="Declaration"/>を使用する。
    /// </remarks>
    public interface IDeclarationContainer
    {
        #region Public properties

        /// <summary>
        /// 頂点宣言を取得する
        /// </summary>
        D3D.VertexDeclaration VertexDeclaration
        {
            get;
        }

        /// <summary>
        /// 頂点のフォーマットを取得する
        /// </summary>
        D3D.VertexFormat Format
        {
            get;
        }

        /// <summary>
        /// 頂点あたりのバイト数
        /// </summary>
        int SizeInBytes
        {
            get;
        }

        #endregion
    }
}
