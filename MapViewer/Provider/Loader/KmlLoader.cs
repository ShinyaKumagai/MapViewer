using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Loader
{
    /// <summary>
    /// KMLファイルから地図データを読み込むためのローダ
    /// </summary>
    public class KmlLoader : ILoader
    {
        #region ILoader methods

        public IList<Geometory.Polygon> Load(string path)
        {
            Kml kml = null;
            try
            {
                kml = ParseLegacyFile(path).Root as Kml;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return ToPolygons(kml);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// KMLファイルからポリゴンを抽出する
        /// </summary>
        /// <param name="kml">KMLファイル</param>
        /// <returns>読み込んだポリゴン</returns>
        private IList<Geometory.Polygon> ToPolygons(Kml kml)
        {
            var polygons = new List<Geometory.Polygon>();

            // KMLファイルからポリゴンを構成する座標を取得する
            foreach (var coords in kml.Feature.Flatten().OfType<CoordinateCollection>())
            {
                var polygon = new Geometory.Polygon();
                var points = from c in coords
                             select new PointF((float)c.Longitude, (float)c.Latitude);
                polygon.Points = points.ToList();

                polygons.Add(polygon);
            }

            return polygons;
        }

        private KmlFile ParseLegacyFile(string path)
        {
            // Manually parse the Xml
            string xml = File.ReadAllText(path);

            var parser = new Parser();
            // Ignore the namespaces
            parser.ParseString(xml, false);

            // The element will be stored in parser.Root - wrap it inside a KmlFile.
            return KmlFile.Create(parser.Root, true);
        }

        #endregion
    }
}
