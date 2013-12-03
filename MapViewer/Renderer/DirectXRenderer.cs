using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Renderer
{
    /// <summary>
    /// DirextXを使用する地図レンダラ
    /// </summary>
    public class DirectXRenderer : IRenderer
    {
        #region Public methods

        public void Render(Graphics graphics, IList<Geometory.Polygon> polygons)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
