using MapViewer.Converter.DirectX;
using MapViewer.Geometory;
using MapViewer.Geometory.DirectX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MapViewer.Provider
{
    /// <summary>
    /// DirectX用の2Dポリゴンを作成する
    /// </summary>
    public class DXPolygonProvider : IProvider<DXPolygon>
    {
        #region Public properties

        /// <summary>
        /// フォームスクリーン座標のポリゴンプロバイダ
        /// </summary>
        public IProvider<Polygon> PolygonProvider
        {
            private get;
            set;
        }

        #endregion

        #region Constrcutor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public DXPolygonProvider() :
            this(null)
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="polygonProvider">フォームスクリーン座標のポリゴンプロバイダ</param>
        public DXPolygonProvider(IProvider<Polygon> polygonProvider)
        {
            PolygonProvider = polygonProvider;
        }

        #endregion

        #region Public methods

        public IList<DXPolygon> Provide(Size displaySize)
        {
            if (PolygonProvider == null)
            {
                return null;
            }

            var srcPolygons = PolygonProvider.Provide(displaySize);
            // 変換元のポリゴンが作成できなかった場合
            if (srcPolygons == null)
            {
                return null;
            }
            // Formのスクリーン座標からDirectXのスクリーン座標に変換する
            return new DXScreenCoordConverter().Convert(srcPolygons);
        }

        #endregion

    }
}
