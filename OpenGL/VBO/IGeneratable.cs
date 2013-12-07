using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.OpenGL.VBO
{
    /// <summary>
    /// VBOを作成するためのインターフェース
    /// </summary>
    /// <typeparam name="T">頂点の型</typeparam>
    public interface IGeneratable<T> : IDeletable where T : struct
    {
        #region Public methods

        /// <summary>
        /// VBOを作成する
        /// </summary>
        /// <param name="vertices">バッファに転送する頂点配列</param>
        void Generate(T[] vertices);

        #endregion
    }
}
