using MapViewer.Geometory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer.Loader
{
    /// <summary>
    /// 地図データを読み込むためのインターフェース
    /// </summary>
    public interface ILoader
    {
        #region Public methods

        /// <summary>
        /// 地図データからポリゴンを読み込む
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>座標データ</returns>
        IList<Polygon> Load(string path);

        #endregion
    }
}
