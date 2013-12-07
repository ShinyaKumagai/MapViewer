using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using MapViewer.OpenGL.VBO;
using MapViewer.OpenGL.Camera;

namespace OpenGLView
{
    public partial class OpenGLControl : GLControl
    {
        private Quad2D _quad2D;
        private Camera2D _camera;


        public OpenGLControl()
        {
            InitializeComponent();

            _camera = new Camera2D(new Vector2(ClientSize.Width, ClientSize.Height));
        }

        public void Unload()
        {
            _quad2D.Delete();
        }

        private void OpenGLControl_Load(object sender, EventArgs e)
        {
            // ポリゴンの裏面を描画しないようにする
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            // 頂点の順番を半時計回りにすると表になる
            GL.FrontFace(FrontFaceDirection.Ccw);

            _quad2D = new Quad2D(new Vector2(100, 100));
        }

        private void OpenGLControl_Resize(object sender, EventArgs e)
        {
            GL.Viewport(ClientRectangle);
            _camera.ClipSize = new Vector2(ClientSize.Width, ClientSize.Height);

            //GL.MatrixMode(MatrixMode.Projection);
            //Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4,
            //    (float)ClientSize.Width / (float)ClientSize.Height, 1.0f, 64.0f);
            //GL.LoadMatrix(ref projection);
        }

        private void OpenGLControl_Paint(object sender, PaintEventArgs e)
        {
            MakeCurrent();

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.White);

            _camera.Update();

            SwapBuffers();
        }
    }
}
