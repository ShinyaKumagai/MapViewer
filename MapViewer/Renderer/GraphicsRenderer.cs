using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Renderer
{
    /// <summary>
    /// <see cref="Graphics"/>を使用する地図レンダラ
    /// </summary>
    public class GraphicsRenderer : IRenderer
    {
        #region Public methods

        public void Render(Graphics graphics, IList<Geometory.Polygon> polygons)
        {
            foreach (var polygon in polygons)
            {
                graphics.DrawLines(Pens.Black, polygon.Points.ToArray());
            }
        }

        #endregion
    }
}
