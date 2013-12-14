using SlimDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Graphics.DirectX.Vertex
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// 位置情報のみの頂点情報
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexPosition
    {
        #region Public class

        /// <summary>
        /// 頂点宣言
        /// </summary>
        public sealed class Declaration : IDeclarationContainer
        {
            #region Private fields

            /// <summary>
            /// 頂点あたりのバイト数
            /// </summary>
            private static readonly int _SizeInBytes = Marshal.SizeOf(default(VertexPosition));

            #endregion

            #region Public properties

            #region IVertexDeclaration

            public D3D.VertexDeclaration VertexDeclaration
            {
                get;
                private set;
            }

            public D3D.VertexFormat Format
            {
                get 
                {
                    return D3D.VertexFormat.Position;
                }
            }

            public int SizeInBytes
            {
                get
                {
                    return _SizeInBytes;
                }
            }

            #endregion

            #endregion

            #region Constructor

            /// <summary>
            /// 新しいインスタンスを作成する
            /// </summary>
            /// <param name="device">D3Dデバイス</param>
            public Declaration(D3D.Device device)
            {
                VertexDeclaration = new D3D.VertexDeclaration(device,
                    new[] 
                    {
				        new D3D.VertexElement(0, 0, D3D.DeclarationType.Float2, D3D.DeclarationMethod.Default, D3D.DeclarationUsage.Position, 0), 
				        D3D.VertexElement.VertexDeclarationEnd
        	        }
                );
            }

            #endregion
        }

        #endregion

        #region Private fields

        /// <summary>
        /// 頂点宣言
        /// </summary>
        private static D3D.VertexDeclaration VertexDeclaration;

        #endregion

        #region Public properties

        /// <summary>
        /// 頂点の位置
        /// </summary>
        public Vector2 Position
        {
            get;
            set;
        }

        #endregion
    }
}
