using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Graphics.DirectX.Vertex;
using Graphics.DirectX.VertexBuffer;
using SlimDX;

namespace Graphics.DirectX.Primitive
{
    using D3D = SlimDX.Direct3D9;
    using System.Drawing;

    /// <summary>
    /// 4頂点のみの2Dポリゴン
    /// </summary>
    public class Quad2D : IRenderable, IDisposable
    {
        #region Private fields

        /// <summary>
        /// 頂点バッファ
        /// </summary>
        private IDynamicVertexBuffer<VertexPosition> _vertexBuffer;

        /// <summary>
        /// ポリゴンのサイズ
        /// </summary>
        private SizeF _size;

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="width">ポリゴンの幅</param>
        /// <param name="height">ポリゴンの高さ</param>
        public Quad2D(float width, float height) :
            this(new SizeF(width, height))
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="size">ポリゴンのサイズ</param>
        public Quad2D(SizeF size)
        {
            _size = size;
        }

        #endregion

        #region Public methods

        #region IDisposable

        public void Dispose()
        {
            _vertexBuffer.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IRendarable

        public void Render(D3D.Device device)
        {
            _vertexBuffer.SetStreamSource(device);

            device.DrawPrimitives(D3D.PrimitiveType.TriangleStrip, 0, 2);
        }

        #endregion

        /// <summary>
        /// 頂点バッファを作成する
        /// </summary>
        /// <param name="device">D3Dデバイス</param>
        public void CreateVertexBuffer(D3D.Device device)
        {
            var declaration = new VertexPosition.Declaration(device);
            _vertexBuffer = new DynamicVertexBuffer<VertexPosition>(device, declaration);

            var vertices = new VertexPosition[] 
            {
                // 左上
                new VertexPosition()
                {
                    Position = Vector2.Zero,
                },
                // 右上
                new VertexPosition()
                {
                    Position = new Vector2(_size.Width, 0),
                },
                // 左下
                new VertexPosition()
                {
                    Position = new Vector2(0, _size.Height),
                },
                // 右下
                new VertexPosition()
                {
                    Position = new Vector2(_size.Width, _size.Height),
                },
            };
            _vertexBuffer.Add(vertices);
            _vertexBuffer.Commit();
        }

        #endregion
    }
}
