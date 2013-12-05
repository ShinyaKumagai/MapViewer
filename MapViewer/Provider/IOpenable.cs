using MapViewer.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Provider
{
    /// <summary>
    /// 地図データからポリゴンを作成するためのインターフェース
    /// </summary>
    public interface IOpenable
    {
        #region Public methods

        /// <summary>
        /// プロバイダからポリゴンを作成する
        /// </summary>
        /// <param name="provider">ポリゴンのプロバイダ</param>
        void Open(IProvider provider);

        #endregion
    }
}
