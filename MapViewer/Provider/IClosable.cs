using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.Provider
{
    /// <summary>
    /// プロバイダから作成したオブジェクトを破棄するためのインターフェース
    /// </summary>
    public interface IClosable
    {
        #region Public methods

        /// <summary>
        /// オブジェクトを解放する
        /// </summary>
        void Close();

        #endregion
    }
}
