using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics.OpenGL.Primitive
{
    /// <summary>
    /// VBOの描画インターフェース
    /// </summary>
    public interface IRenderable
    {
        #region Public methods

        /// <summary>
        /// VBOを描画する
        /// </summary>
        void Render();

        #endregion
    }
}
