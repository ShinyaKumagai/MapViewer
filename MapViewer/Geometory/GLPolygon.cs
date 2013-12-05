using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Geometory
{
    public class GLPolygon : IPolygon<Vector2>
    {
        #region Public properties

        /// <summary>
        /// ポリゴンを構成する座標
        /// </summary>
        public IList<Vector2> Points
        {
            get;
            set;
        }

        #endregion

        #region Public methods

        #region IEnumerable metthods

        public IEnumerator<Vector2> GetEnumerator()
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
