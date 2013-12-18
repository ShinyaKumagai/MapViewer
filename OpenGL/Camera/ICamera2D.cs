using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.OpenGL.Camera
{
    /// <summary>
    /// 2D描画用のカメラインタフェース
    /// </summary>
    /// <remarks>
    /// オブジェクト描画前に必ずカメラの更新処理を呼ぶ
    /// </remarks>
    public interface ICamera2D
    {
        #region Public properties

        /// <summary>
        /// クリップ面のサイズ
        /// </summary>
        /// <remarks>
        /// カメラが移す範囲の幅および高さになる。
        /// </remarks>
        SizeF ClipSize
        {
            get;
            set;
        }

        /// <summary>
        /// クリップ面の中心座標
        /// </summary>
        PointF ClipCenter
        {
            get;
        }

        /// <summary>
        /// ズーム値
        /// </summary>
        /// <remarks>
        /// 正射影で描画するのでズーム値を使用してクリップ面のサイズ拡縮
        /// させることでズームするために使用する。
        /// </remarks>
        float Zoom
        {
            get;
            set;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// 射影行列を設定する
        /// </summary>
        void Update();

        #endregion
    }
}
