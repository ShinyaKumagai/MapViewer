using MapViewer.OpenGL.Vertex;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.OpenGL.VBO
{
    /// <summary>
    /// 頂点バッファオブジェクトのインタフェース。
    /// </summary>
    /// <typeparam name="T">頂点の型</typeparam>
    /// <remarks>
    /// 現在は1つのバッファのみ使用できるようになっている
    /// </remarks>
    public class VertexBufferObject<T> : IGeneratable<T>, IBindable
        where T : struct
    {
        #region Private fields

        /// <summary>
        /// VBOの識別ID
        /// </summary>
        /// <remarks>
        /// 値が-1の場合はVBOは作成されていない。
        /// </remarks>
        private int _id;

        /// <summary>
        /// バッファに格納する頂点情報の定義
        /// </summary>
        private IVertexElement _element;

        #endregion

        #region Public properties

        /// <summary>
        /// 頂点数
        /// </summary>
        public int VertexCount
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="element">頂点情報の定義</param>
        public VertexBufferObject(IVertexElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("elementが空です。");
            }

            _id = -1;
            _element = element;
            VertexCount = 0;
        }

        #endregion

        #region Public methods

        #region IGeneratable

        public void Generate(T[] vertices)
        {
            // VBOが作成されている場合は削除しておく
            Delete();

            // VBOを作成する
            GL.GenBuffers(1, out _id);
            // バッファを転送するVBOに指定する
            GL.BindBuffer(BufferTarget.ArrayBuffer, _id);

            // 頂点配列をバッファに転送する
            int size = vertices.Length * _element.SizeInBytes;
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(size), vertices, BufferUsageHint.StaticDraw);

            // VBOの指定を解除する
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            // 頂点の数
            VertexCount = vertices.Length;
        }

        public void Delete()
        {
            if (_id == -1)
            {
                return;
            }
            // VBOを削除する
            GL.DeleteBuffers(1, ref _id);
        }

        #endregion

        #region IBindable

        public void Bind()
        {
            // VBOをOpenGLの操作対象に指定する
            GL.BindBuffer(BufferTarget.ArrayBuffer, _id);
            _element.Bind();
        }

        public void Unbind()
        {
            // VBOをOpenGLの操作対象から解除する
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            _element.Unbind();
        }

        #endregion

        #endregion
    }
}
