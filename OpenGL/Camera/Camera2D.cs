using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
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

        public Vector2 ClipSize
        {
            get;
            set;
        }

        public Vector2 ClipCenter
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
            this(new Vector2(1, 1))
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="width">クリップ面の幅</param>
        /// <param name="height">クリップ面の高さ</param>
        public Camera2D(int width, int height) :
            this(new Vector2(width, height))
        {
        }

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="clipSize">クリップ面のサイズ</param>
        public Camera2D(Vector2 clipSize)
        {
            ClipSize = clipSize;
            ClipCenter = Vector2.Zero;
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
            var halfSize = ClipSize / 2;
            var clip = new {
                           Left   = ClipCenter.X - halfSize.X,
                           Top    = ClipCenter.Y - halfSize.Y,
                           Right  = ClipCenter.X + halfSize.X,
                           Bottom = ClipCenter.Y + halfSize.Y
                       };
            // 現在の行列にクリップ面から計算する正射影行列を適用する
            GL.Ortho(clip.Left, clip.Right, clip.Bottom, clip.Top, -1d, 1d);
        }

        #endregion

        #endregion
    }
}
