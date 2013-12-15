using Graphics.DirectX.Vertex;
using Graphics.DirectX.VertexBuffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics.DirectX.Primitive
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// ポリゴンの外枠のライン
    /// </summary>
    public class LinePolygon : IPrimitive<VertexPosition>
    {
        #region Private fields

        /// <summary>
        /// 頂点バッファ
        /// </summary>
        private IDynamicVertexBuffer<VertexPosition> _vertexBuffer;

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

            device.DrawPrimitives(D3D.PrimitiveType.PointList, 0, _vertexBuffer.VertexCount);
        }

        #endregion

        #region IPrimitive
        
        /// <summary>
        /// 頂点バッファを作成する
        /// </summary>
        /// <param name="device">D3Dデバイス</param>
        public void CreateVertexBuffer(D3D.Device device, VertexPosition[] vertices)
        {
            var declaration = new VertexPosition.Declaration(device);
            _vertexBuffer = new DynamicVertexBuffer<VertexPosition>(device, declaration);

            _vertexBuffer.Add(vertices);
            _vertexBuffer.Commit();
        }

        #endregion

        #endregion
    }
}
