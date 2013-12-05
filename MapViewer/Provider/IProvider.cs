using MapViewer.Geometory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Provider
{
    public interface IProvider
    {
        IList<Polygon> Provide(string filepath);
    }
}
