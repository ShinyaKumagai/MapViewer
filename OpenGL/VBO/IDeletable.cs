using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.OpenGL.VBO
{
    /// <summary>
    /// VBOを削除するためのインターフェース
    /// </summary>
    public interface IDeletable
    {
        #region Public methods

        /// <summary>
        /// VBOを削除する
        /// </summary>
        void Delete();

        #endregion
    }
}
