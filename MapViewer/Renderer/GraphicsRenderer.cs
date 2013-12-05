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
    /// <see cref="Graphics"/>を使用する地図レンダラ
    /// </summary>
    public class GraphicsRenderer : IRenderer<Polygon>
    {
        #region Public methods

        public void Render(Graphics graphics, IList<Polygon> polygons)
        {
            foreach (var polygon in polygons)
            {
                var pen = new Pen(polygon.Style.OutlineColor);
                graphics.DrawLines(pen, polygon.Points.ToArray());
            }
        }

        #endregion
    }
}
