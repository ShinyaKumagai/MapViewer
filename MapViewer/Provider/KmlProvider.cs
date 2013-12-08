using MapViewer.Converter;
using MapViewer.Geometory;
using MapViewer.Loader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MapViewer.Provider
{
    /// <summary>
    /// KMLファイルからポリゴンを作成するためのクラス
    /// </summary>
    public class KmlProvider : PolygonProvider
    {
        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public KmlProvider()
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="filepath">ファイルパス</param>
        public KmlProvider(string filepath) :
            base(filepath)
        {
        }

        #endregion

        #region PolygonProvider

        protected override ILoader CreateLoader()
        {
            return new KmlLoader();
        }

        protected override IConverter<Polygon> CreateConveter(Size displaySize)
        {
            int displayLength = Math.Min(displaySize.Width, displaySize.Height);
            return new ScreenCoordConverter(displayLength);
        }

        #endregion
    }
}
