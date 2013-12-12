using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.DirectX.VertexBuffer
{
    public class DynamicVertexBuffer<T> : IDynamicVertexBuffer<T>, IDisposable
        where T : struct
    {
    }
}
