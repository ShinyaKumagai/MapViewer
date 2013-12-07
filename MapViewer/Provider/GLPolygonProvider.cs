using MapViewer.Converter.OpenGL;
using MapViewer.Geometory;
using MapViewer.Geometory.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MapViewer.Provider.OpenGL
{
    /// <summary>
    /// 
    /// </summary>
    public class GLPolygonProvider : IProvider<GLPolygon>
    {
        #region Public properties

        /// <summary>
        /// スクリーン座標のポリゴンプロバイダ
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
        public GLPolygonProvider() :
            this(null)
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="polygonProvider">スクリーン座標のポリゴンプロバイダ</param>
        public GLPolygonProvider(IProvider<Polygon> polygonProvider)
        {
            PolygonProvider = polygonProvider;
        }

        #endregion

        #region Public methods

        public IList<GLPolygon> Provide(Size displaySize)
        {
            if (PolygonProvider == null)
            {
                return null;
            }

            var srcPolygons = PolygonProvider.Provide(displaySize);
            // 変換元のポリゴンが提供できない場合
            if (srcPolygons == null)
            {
                return null;
            }
            return new GLVectorConverter().Convert(srcPolygons);
        }

        #endregion
    }
}
