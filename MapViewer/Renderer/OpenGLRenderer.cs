using MapViewer.Geometory;
using MapViewer.Geometory.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Renderer.OpenGL
{
    using GraphicsContext = System.Drawing.Graphics;

    /// <summary>
    /// OpenGLを使用する地図レンダラ
    /// </summary>
    public class OpenGLRenderer : IRenderer<GLPolygon>
    {
        #region Public methods

        public void Render(GraphicsContext graphics, IList<GLPolygon> polygons)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
