using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MapViewer.Geometory
{
    /// <summary>
    /// ポリゴンのスタイルのインターフェース
    /// </summary>
    /// <remarks>
    /// 現在はポリゴンの外枠の色のみ
    /// </remarks>
    public class Style
    {
        #region Public properties

        /// <summary>
        /// ポリゴンの外枠の色
        /// </summary>
        public Color OutlineColor
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public Style()
        {
            OutlineColor = Color.Black;
        }

        #endregion
    }
}
