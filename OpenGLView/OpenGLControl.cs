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

namespace OpenGLView
{
    public partial class OpenGLControl : GLControl
    {
        public OpenGLControl()
        {
            InitializeComponent();
        }

        private void OpenGLControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.White);
            GL.Enable(EnableCap.DepthTest);
        }

        private void OpenGLControl_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4,
                (float)ClientSize.Width / (float)ClientSize.Height, 1.0f, 64.0f);
            GL.LoadMatrix(ref projection);
        }

        private void OpenGLControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.LoadMatrix(ref modelview);

            GL.Begin(BeginMode.Quads);

            GL.Color4(Color4.White);
            GL.Vertex3(-1.0f, 1.0f, 4.0f);
            GL.Color4(Color4.Red);
            GL.Vertex3(-1.0f, -1.0f, 4.0f);
            GL.Color4(Color4.Lime);
            GL.Vertex3(1.0f, -1.0f, 4.0f);
            GL.Color4(Color4.Blue);
            GL.Vertex3(1.0f, 1.0f, 4.0f);

            GL.End();
            SwapBuffers();
        }
    }
}
