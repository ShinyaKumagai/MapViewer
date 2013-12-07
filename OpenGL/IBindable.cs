using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.OpenGL
{
    /// <summary>
    /// GLの操作対象に設定するためのインターフェース
    /// </summary>
    public interface IBindable
    {
        #region Public methods

        /// <summary>
        /// OpenGLの操作対象に設定する
        /// </summary>
        void Bind();

        /// <summary>
        /// OpenGLの操作対象から解除する
        /// </summary>
        void Unbind(); 

        #endregion
    }
}
