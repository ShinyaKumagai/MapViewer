using MapViewer.OpenGL.Vertex;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.OpenGL.VBO.Primitive
{
    /// <summary>
    /// 4頂点のみの2DポリゴンのVBO
    /// </summary>
    /// <remarks>
    /// 不要になった場合は必ず<seealso cref="Delete"/>を呼び内部で保持しているVBOを削除する。
    /// </remarks>
    public class Quad2D : IBindable, IDeletable, IRenderable
    {
        #region Private fields

        /// <summary>
        /// 頂点バッファオブジェクト
        /// </summary>
        private VertexBufferObject<VertexPosition> _vbo;

        /// <summary>
        /// ポリゴンのサイズ
        /// </summary>

        private Vector2 _size;

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="width">ポリゴンの幅</param>
        /// <param name="height">ポリゴンの高さ</param>
        public Quad2D(float width, float height) :
            this(new Vector2(width, height))
        {

        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="size">ポリゴンのサイズ</param>
        /// <remarks>
        /// コンストラクタ内でVBOを作成する
        /// </remarks>
        public Quad2D(Vector2 size)
        {
            _size = size;
            CreateVertexBufferObject();
        }

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

        #region IDeletable

        public void Delete()
        {
            _vbo.Delete();
        }

        #endregion

        #region IRenderer

        public void Render()
        {
            Bind();

            GL.DrawArrays(BeginMode.TriangleStrip, 0, _vbo.VertexCount);

            Unbind();
        }

        #endregion

        #endregion

        #region Private methods

        private void CreateVertexBufferObject()
        {
            _vbo = new VertexBufferObject<VertexPosition>(new VertexPosition.Declaration());
            var vertices = new VertexPosition[4]
            {
                // 左下
                new VertexPosition()
                {
                    Position = new Vector2(0, _size.Y),
                },
                // 右下
                new VertexPosition()
                {
                    Position = _size,
                },
                // 左上
                new VertexPosition()
                {
                    Position = Vector2.Zero,
                },
                // 右上
                new VertexPosition()
                {
                    Position = new Vector2(_size.X, 0)
                },
            };

            _vbo.Generate(vertices);
        }

        #endregion
    }
}
