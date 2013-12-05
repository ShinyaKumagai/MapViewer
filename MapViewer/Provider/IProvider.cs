using MapViewer.Geometory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MapViewer.Provider
{
    /// <summary>
    /// ポリゴンを作成するためのインターフェース
    /// </summary>
    public interface IProvider
    {
        #region Public methods

        /// <summary>
        /// ポリゴンを作成する
        /// </summary>
        /// <param name="displaySize">描画領域のサイズ</param>
        /// <returns>作成したポリゴンリスト</returns>
        /// <remarks>
        /// ポリゴンの座標はスクリーン座標に変換済み。
        /// </remarks>
        IList<Polygon> Provide(Size displaySize);

        #endregion
    }
}
