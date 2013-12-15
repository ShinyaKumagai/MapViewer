using MapViewer.Geometory;
using MapViewer.Geometory.DirectX;
using SlimDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Converter.DirectX
{
    /// <summary>
    /// DirectXのスクリーン座標系の<see cref="Vector2"/>型のポリゴン変換する
    /// </summary>
    /// <remarks>
    /// <see cref="IProvider"/>で作成するポリゴンは<see cref="PointF"/>型なので
    /// Direct3D用の座標にに変化する必要がある。
    /// Form:左下、DirectX(今回の場合):右上
    /// </remarks>

    public class DXScreenCoordConverter : IConverter<DXPolygon>
    {
        #region Public methods

        #region IConverter

        public IList<DXPolygon> Convert(IList<Polygon> sourcePolygons)
        {
            if (sourcePolygons == null || sourcePolygons.Count == 0)
            {
                return null;
            }

            // DirectXの座標に変換する
            var destPolygons = new List<DXPolygon>(sourcePolygons.Count);
            foreach (var srcPolygon in sourcePolygons)
            {
                var destPolygon = new DXPolygon();
                destPolygon.Points = srcPolygon.Select(p =>
                {
                    return new Vector2(p.X, p.Y);
                }).ToList();
                destPolygons.Add(destPolygon);
            }
            return destPolygons;

        }

        #endregion

        #endregion
    }
}
