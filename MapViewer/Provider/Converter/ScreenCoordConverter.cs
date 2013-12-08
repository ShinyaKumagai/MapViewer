using MapViewer.Geometory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Converter
{
    /// <summary>
    /// ポリゴンを画面座標に変換する
    /// </summary>
    public class ScreenCoordConverter : IConverter<Polygon>
    {
        #region Public properties

        /// <summary>
        /// 表示領域（高さ、幅）の短いほうの長さ
        /// </summary>
        /// <remarks>
        /// ポリゴンの縮尺を計算するために使用する
        /// </remarks>
        public float DisplayLength
        {
            private get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public ScreenCoordConverter() :
            this(1f)
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="srcPolygons">変換元のポリゴン</param>
        /// <param name="displayLength"></param>
        public ScreenCoordConverter(float displayLength)
        {
            DisplayLength = displayLength;
        }

        #endregion

        #region Public methods

        #region IConverter

        public IList<Polygon> Convert(IList<Polygon> sourcePolygons)
        {
            if (sourcePolygons == null || sourcePolygons.Count == 0)
            {
                return　null;
            }

            // 全ポリゴンの表示範囲を計算する
            var min = new PointF(float.MaxValue, float.MaxValue);
            var max = new PointF(float.MinValue, float.MinValue);
            foreach (var polygon in sourcePolygons)
            {
                foreach (var p in polygon)
                {
                    min.X = Math.Min(min.X, p.X);
                    min.Y = Math.Min(min.Y, p.Y);
                    max.X = Math.Max(max.X, p.X);
                    max.Y = Math.Max(max.Y, p.Y);
                }
            }

            // ポリゴンを画面内に収めるための縮尺を計算する。
            float ratio = DisplayLength / Math.Max(max.X - min.X, max.Y - min.Y);

            var destPolygons = new List<Polygon>(sourcePolygons.Count);
            // 左下を原点とした座標に変換する。
            foreach (var srcPolygon in sourcePolygons)
            {
                var destPolygon = new Polygon();
                var points = srcPolygon.Select(p => new PointF()
                                                     {
                                                         X = -(min.X - p.X) * ratio,
                                                         Y =  (max.Y - p.Y) * ratio
                                                     });
                destPolygon.Points = points.ToList();
                destPolygons.Add(destPolygon);
            }
            return destPolygons;
        }

        #endregion

        #endregion
    }
}
