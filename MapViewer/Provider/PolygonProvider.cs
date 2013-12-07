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
    public abstract class PolygonProvider : IProvider<Polygon>
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

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public PolygonProvider() :
            this(String.Empty)
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="filepath">ファイルパス</param>
        public PolygonProvider(string filepath)
        {
            Filepath = filepath;

            // イベントにヌルオブジェクトをセットしておく
            ProvideBegin += (_s, _e) => { };
            ProvideEnd += (_s, _e) => { };
        }

        #endregion

        #region Public methods

        public IList<Polygon> Provide(Size displaySize)
        {
            // 処理の開始前のイベントを発生させる。
            ProvideBegin(this, EventArgs.Empty);

            var stopwatch = Stopwatch.StartNew();

            // ファイルからポリゴンを読み込む。
            var srcPolygons = CreateLoader().Load(Filepath);
            Console.WriteLine("Loadede file : {0}", stopwatch.Elapsed);

            // 読み込んだポリゴンの座標をスクリーン座標に変換する。
            var converter = new ScreenConverter()
            {
                DisplayLength = Math.Min(displaySize.Width, displaySize.Height),
            };
            var destPolygons = converter.Convert(srcPolygons);
            Console.WriteLine("Converted polygons : {0}", stopwatch.Elapsed);

            // 処理の開始後のイベントを発生させる
            ProvideEnd(this, EventArgs.Empty);

            return destPolygons;
        }

        #endregion

        #region Abstract methods

        /// <summary>
        /// ポリゴンのローダを取得する
        /// </summary>
        /// <returns>ポリゴンのローダ</returns>
        protected abstract ILoader CreateLoader();

        #endregion

    }
}
