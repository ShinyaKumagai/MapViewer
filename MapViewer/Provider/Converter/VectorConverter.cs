using MapViewer.Geometory;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Converter
{
    /// <summary>
    /// <see cref="Vector2"/>型のポリゴン変換する
    /// </summary>
    /// <remarks>
    /// <see cref="IProvider"/>で作成するポリゴンは<see cref="PointF"/>型なので
    /// OpenGL用の座標にに変化する必要がある。
    /// </remarks>
    public class VectorConverter : IConverter<GLPolygon>
    {
        #region Public properties

        /// <summary>
        /// 変換対象のポリゴン
        /// </summary>
        public IList<Polygon> SourcePolygons
        {
            private get;
            set;
        }

        #endregion

        #region Constrcutor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public VectorConverter() :
            this(new List<Polygon>())
        {

        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="srcPolygon">変換元のポリゴン</param>
        public VectorConverter(IList<Polygon> srcPolygon)
        {

        }

        #endregion

        #region IConverter

        public IList<GLPolygon> Convert(IList<Polygon> sorucePolygons)
        {
            if (SourcePolygons == null || SourcePolygons.Count == 0)
            {
                return null;
            }

            var destPolygons = new List<GLPolygon>(SourcePolygons.Count);
            // PointF型の座標をVector2型に変換する。
            foreach (var srcPolygon in SourcePolygons)
            {
                var destPolygon = new GLPolygon();
                destPolygon.Points =  srcPolygon.Select(p => new Vector2(p.X, p.Y)).ToList();
                destPolygons.Add(destPolygon);
            }
            return destPolygons;
        }

        #endregion
    }
}
