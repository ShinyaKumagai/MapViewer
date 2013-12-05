using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Geometory
{
    /// <summary>
    /// ポリゴンのインターフェース
    /// </summary>
    /// <typeparam name="T">座標型</typeparam>
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

        /// <summary>
        /// ポリゴンのスタイル
        /// </summary>
        Style Style
        {
            get;
            set;
        }

        #endregion
    }
}
