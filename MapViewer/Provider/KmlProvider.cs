using MapViewer.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Provider
{
    /// <summary>
    /// KMLファイルからポリゴンを作成するためのクラス
    /// </summary>
    public class KmlProvider : PolygonProvider
    {
        #region PolygonProvider

        protected override ILoader CreateLoader()
        {
            return new KmlLoader();
        }

        #endregion
    }
}
