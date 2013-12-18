using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.OpenGL.Camera
{
    /// <summary>
    /// 2D描画用のカメラ
    /// </summary>
    public class Camera2D : ICamera2D
    {
        #region Private fields

        /// <summary>
        /// カメラのズーム値
        /// </summary>
        private float _zoom;

        #endregion

        #region Public properties

        #region ICamera2D

        public SizeF ClipSize
        {
            get;
            set;
        }

        public PointF ClipCenter
        {
            get;
            private set;
        }

        public float Zoom
        {
            get { return _zoom;  }
            set 
            {
                if (value == 0f)
                {
                    throw new ArgumentException("ズーム値に0を設定することはできません");
                }
                _zoom = value;
            }
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public Camera2D() :
            this(new SizeF(1f, 1f))
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="width">クリップ面の幅</param>
        /// <param name="height">クリップ面の高さ</param>
        public Camera2D(float width, float height) :
            this(new SizeF(width, height))
        {
        }


        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="clipSize">クリップ面のサイズ</param>
        public Camera2D(Size clipSize) :
            this(new SizeF(clipSize.Width, clipSize.Height))
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="clipSize">クリップ面のサイズ</param>
        public Camera2D(SizeF clipSize)
        {
            ClipSize = clipSize;
            ClipCenter = PointF.Empty;
            Zoom = 1f;
        }

        #endregion

        #region Public methods

        #region ICamera

        public void Update()
        {
            // 射影行列の設定を行う
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // クリップ面を計算する
            var halfSize = new SizeF(ClipSize.Width * .5f, ClipSize.Height * .5f);
            var clip = new {
                           Left   = ClipCenter.X - halfSize.Width,
                           Top    = ClipCenter.Y + halfSize.Height,
                           Right  = ClipCenter.X + halfSize.Width,
                           Bottom = ClipCenter.Y - halfSize.Height
                       };
            // 現在の行列にクリップ面から計算する正射影行列を適用する
            GL.Ortho(clip.Left, clip.Right, clip.Bottom, clip.Top, -1d, 1d);
        }

        #endregion

        #endregion
    }
}
