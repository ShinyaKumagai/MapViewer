using MapViewer.Geometory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Renderer
{
    using GraphicsContext = System.Drawing.Graphics;

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
        void Render(GraphicsContext graphics, IList<T> polygons);

        #endregion
    }
}
