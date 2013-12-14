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
    /// DirextXを使用する地図レンダラ
    /// </summary>
    public class D3DRenderer : IRenderer<Polygon>
    {
        #region Public methods

        public void Render(GraphicsContext graphics, IList<Polygon> polygons)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
