﻿using SlimDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Geometory.DirectX
{
    /// <summary>
    /// Direct3D用のポリゴン
    /// </summary>
    public class DXPolygon : IPolygon<Vector2>
    {
        #region Public properties

        public IList<Vector2> Points
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
        public DXPolygon()
        {
            Points = new List<Vector2>();
            Style = new Style();
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
