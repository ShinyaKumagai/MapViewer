using MapViewer.Geometory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Renderer
{
    /// <summary>
    /// ポリゴンの描画インターフェース
    /// </summary>
    /// <typeparam name="T">描画するポリゴン型</typeparam>
    public interface IRenderer<T>
    {
        #region Public methods

        /// <summary>
        /// ポリゴンの描画処理
        /// </summary>
        /// <param name="graphics">グラフィックス</param>
        /// <param name="polygons">描画するポリゴン</param>
        void Render(Graphics graphics, IList<T> polygons);

        #endregion
    }
}
