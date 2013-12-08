using MapViewer.OpenGL.Vertex;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.OpenGL.VBO.Primitive
{
    /// <summary>
    /// ポリゴンの外枠ラインのVBO
    /// </summary>
    public class LinePolygon : IBindable, IGeneratable<VertexPosition>, IRenderable
    {
        #region Private fields

        /// <summary>
        /// 頂点バッファオブジェクト
        /// </summary>
        private VertexBufferObject<VertexPosition> _vbo;

        #endregion

        #region Public methods

        #region IBindable

        public void Bind()
        {
            _vbo.Bind();
        }

        public void Unbind()
        {
            _vbo.Unbind();
        }

        #endregion

        #region IGeneratable

        public void Generate(VertexPosition[] vertices)
        {
            _vbo = new VertexBufferObject<VertexPosition>(new VertexPosition.Attribute());
            _vbo.Generate(vertices);
        }

        public void Delete()
        {
            _vbo.Delete();
        }

        #endregion

        #region IRenderer

        public void Render()
        {
            Bind();

            GL.DrawArrays(BeginMode.LineLoop, 0, _vbo.VertexCount);

            Unbind();
        }

        #endregion

        #endregion
    }
}
