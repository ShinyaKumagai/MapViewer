using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using System.Runtime.InteropServices;

namespace Graphics.DirectX.Vertex
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// 位置情報と頂点カラーの頂点情報
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class VertexPositionColor
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
            private static readonly int _SizeInBytes = Marshal.SizeOf(default(VertexPositionColor));

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
                    return D3D.VertexFormat.Position | D3D.VertexFormat.Diffuse;
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
				        new D3D.VertexElement(0, 8, D3D.DeclarationType.Color, D3D.DeclarationMethod.Default, D3D.DeclarationUsage.Color, 0), 
				        D3D.VertexElement.VertexDeclarationEnd
        	        }
                );
            }

            #endregion
        }

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

        /// <summary>
        /// 頂点カラー
        /// </summary>
        public int Color
        {
            get;
            set;
        }

        #endregion
    }
}
