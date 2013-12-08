using MapViewer.Geometory;
using MapViewer.Geometory.OpenGL;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MapViewer.Converter.OpenGL
{
    /// <summary>
    /// OpenGLの2D座標系の<see cref="Vector2"/>型のポリゴン変換する
    /// </summary>
    /// <remarks>
    /// <see cref="IProvider"/>で作成するポリゴンは<see cref="PointF"/>型なので
    /// OpenGL用の座標にに変化する必要がある。\n
    /// FormとOpenGLの座標系では原点が異なるので変換する必要がある。
    /// Form:左下、OpenGL:中心
    /// </remarks>
    public class GLScreenCoordConverter : IConverter<GLPolygon>
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
        public GLScreenCoordConverter()
        {

        }

        #endregion

        #region IConverter

        public IList<GLPolygon> Convert(IList<Polygon> sourcePolygons)
        {
            if (SourcePolygons == null || SourcePolygons.Count == 0)
            {
                return null;
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
            // 全ポリゴンの中心座標を計算する
            var center = new PointF()
            {
                X = min.X + ((max.X - min.X) * .5f),
                Y = min.Y + ((max.Y - min.Y) * .5f)
            };

            var destPolygons = new List<GLPolygon>(SourcePolygons.Count);
            // PointF型の座標をVector2型に変換する。
            // OpenGLのスクリーン座標系にしておく。
            foreach (var srcPolygon in SourcePolygons)
            {
                var destPolygon = new GLPolygon();
                destPolygon.Points =  srcPolygon.Select(p => 
                    {
                        return new Vector2(-(center.X - p.X), -(center.Y - p.Y));
                    }).ToList();
                destPolygons.Add(destPolygon);
            }
            return destPolygons;
        }

        #endregion
    }
}
