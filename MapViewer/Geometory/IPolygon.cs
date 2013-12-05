using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Geometory
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPolygon<T> : IEnumerable<T>
    {
        #region Public properties

        /// <summary>
        /// ポリゴンを構成する座標
        /// </summary>
        IList<T> Points
        {
            get;
            set;
        }

        #endregion
    }
}
