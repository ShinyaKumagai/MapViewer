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
    public class PolygonConverter : IConverter
    {
        #region Public properties

        /// <summary>
        /// 変換対象のポリゴン
        /// </summary>
        public IList<Polygon> Polygons
        {
            private get;
            set;
        }

        /// <summary>
        /// 画面サイズ
        /// </summary>
        public float DisplaySize
        {
            private get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public PolygonConverter()
        {
        }

        #endregion

        #region Public methods

        #region IConverter

        public IList<Polygon> Convert()
        {
            var min = new PointF(float.MaxValue, float.MaxValue);
            var max = new PointF(float.MinValue, float.MinValue);

            foreach (var polygon in Polygons)
            {
                // 緯度と経度の最大/最少値を取得する
                foreach (var p in polygon)
                {
                    min.X = Math.Min(min.X, p.X);
                    min.Y = Math.Min(min.Y, p.Y);
                    max.X = Math.Max(max.X, p.X);
                    max.Y = Math.Max(max.Y, p.Y);
                }
            }

            // 地図を画面内に収めるための縮尺を計算する。
            float ratio = DisplaySize / Math.Max(max.X - min.X, max.Y - min.Y);

            // 左下を原点とした座標に変換する。
            foreach (var polygon in Polygons)
            {
                var points = from p in polygon
                             select new PointF()
                                     {
                                         X = -(min.X - p.X) * ratio,
                                         Y = (max.Y - p.Y) * ratio
                                     };
                polygon.Points = points.ToList();
            }

            return Polygons;
        }

        #endregion

        #endregion
    }
}
