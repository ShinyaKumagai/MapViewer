using MapViewer.Converter;
using MapViewer.Geometory;
using MapViewer.Loader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapViewer.Provider
{
    /// <summary>
    /// ファイルからポリゴンを作成するためのクラス
    /// </summary>
    public abstract class PolygonProvider
    {
        #region Public properties

        /// <summary>
        /// 地図データのパス
        /// </summary>
        public string Filepath
        {
            get;
            set;
        }

        /// <summary>
        /// 表示領域のサイズ
        /// </summary>
        /// <remarks>
        /// ファイルから読み込んだポリゴンをスクリーン座標に変換する際に使用する。
        /// </remarks>
        public Size DisplaySize
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public PolygonProvider()
        {
            DisplaySize = new Size(1000, 1000);
            Filepath = String.Empty;

            // イベントにヌルオブジェクトをセットしておく
            ProvideBegin += (_s, _e) => { };
            ProvideEnd += (_s, _e) => { };
        }

        #endregion

        #region Public events

        /// <summary>
        /// ポリゴンの作成前に発生します。
        /// </summary>
        public event EventHandler ProvideBegin;

        /// <summary>
        /// ポリゴンの作成後に発生します。
        /// </summary>
        public event EventHandler ProvideEnd;

        #endregion

        #region Public methods

        #region Abstract methods

        /// <summary>
        /// ポリゴンのローダを取得する
        /// </summary>
        /// <returns>ポリゴンのローダ</returns>
        protected abstract ILoader CreateLoader();

        #endregion

        /// <summary>
        /// 読み込んだファイルから>スクリーン座標のポリゴンを作成する
        /// </summary>
        /// <returns>スクリーン座標に変換したポリゴン</returns>
        public IList<Polygon> Provide()
        {
            // 処理の開始前のイベントを発生させる。
            ProvideBegin(this, EventArgs.Empty);

            var stopwatch = Stopwatch.StartNew();

            // ファイルからポリゴンを読み込む。
            var srcPolygons = CreateLoader().Load(Filepath);
            Console.WriteLine("Loadede file : {0}", stopwatch.Elapsed);

            // 読み込んだポリゴンの座標をスクリーン座標に変換する。
            var converter = new PolygonConverter()
            {
                Polygons = srcPolygons,
                DisplaySize = Math.Min(DisplaySize.Width, DisplaySize.Height),
            };
            var destPolygons = converter.Convert();
            Console.WriteLine("Converted polygons : {0}", stopwatch.Elapsed);

            // 処理の開始後のイベントを発生させる
            ProvideEnd(this, EventArgs.Empty);

            return destPolygons;
        }

        #endregion
    }
}
