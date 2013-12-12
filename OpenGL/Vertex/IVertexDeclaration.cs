using MapViewer.OpenGL.VBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.OpenGL.Vertex
{
    /// <summary>
    /// 頂点属性をバインドする時の定義情報
    /// </summary>
    /// <remarks>
    /// 頂点がどのような情報を使用するか定める
    /// </remarks>
    public interface IVertexDeclaration : IBindable
    {
        #region Public properties

        /// <summary>
        /// 頂点のサイズを取得する
        /// </summary>
        int SizeInBytes
        {
            get;
        }

        #endregion
    }
}
