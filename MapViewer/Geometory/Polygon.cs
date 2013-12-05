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
    public class Polygon : IPolygon<PointF>
    {
        #region Public properties

        public IList<PointF> Points
        {
            get;
            set;
        }

        public Style Style
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public Polygon()
        {
            Points = new List<PointF>();
            Style = new Style();
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
