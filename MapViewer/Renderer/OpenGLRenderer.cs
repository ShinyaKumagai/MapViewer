using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Renderer
{
    #region Public methods

    /// <summary>
    /// OpenGLを使用する地図レンダラ
    /// </summary>
    public class OpenGLRenderer : IRenderer
    {
        #region Public methods

        public void Render(Graphics graphics, IList<Geometory.Polygon> polygons)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion
}
