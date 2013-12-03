using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Geometory
{
    /// <summary>
    /// 地図を構成するポリゴン
    /// </summary>
    public class Polygon : IEnumerable<PointF>
    {
        #region Public properties

        /// <summary>
        /// ポリゴンを構成する座標
        /// </summary>
        public IList<PointF> Points
        {
            get;
            set;
        }

        #endregion

        #region Public methods

        #region IEnumerable metthods

        public IEnumerator<PointF> GetEnumerator()
        {
           foreach (var coord in Points)
           {
               yield return coord;
           }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
