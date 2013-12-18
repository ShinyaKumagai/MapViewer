using Graphics.OpenGL.Camera;
using Graphics.OpenGL.VBO;
using Graphics.OpenGL.Primitive;
using Graphics.OpenGL.Vertex;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGLView
{
    public partial class OpenGLForm : Form
    {
        Camera2D _camera = new Camera2D();
        //Quad2D _quad;
        LinePolygon _linePolygon;

        public OpenGLForm()
        {
            InitializeComponent();
        }

        private void OpenGLForm_Load(object sender, EventArgs e)
        {
            //var control = new OpenGLControl();

            //Controls.Add(control);
        }

        private void glUserControl11_Load(object sender, EventArgs e)
        {
            glUserControl11.MakeCurrent();

            // ポリゴンの裏面を描画しないようにする
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            // 頂点の順番を半時計回りにすると表になる
            GL.FrontFace(FrontFaceDirection.Ccw);

            GL.ClearColor(Color.White);

            //_quad = new Quad2D(100f, 100f);

            _linePolygon = new LinePolygon();

            var lines = new VertexPosition[4]
            {
                // 左下
                new VertexPosition()
                {
                    Position = new Vector2(-100, -100),
                },
                // 右下
                new VertexPosition()
                {
                    Position = new Vector2(-100, -100),
                },
                // 左上
                new VertexPosition()
                {
                    Position = new Vector2(-100, 100),
                },
                // 右上
                new VertexPosition()
                {
                    Position = new Vector2(100, 100),
                },
            };
            _linePolygon.Generate(lines);
        }

        private void glUserControl11_Resize(object sender, EventArgs e)
        {
            _camera.ClipSize = ClientSize;
            GL.Viewport(glUserControl11.ClientRectangle);
        }

        private void glUserControl11_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _camera.Update();

            GL.MatrixMode(MatrixMode.Modelview);

            GL.Color4(Color.Red);
            GL.PushMatrix();
            {
                //_quad.Render();
                _linePolygon.Render();
            }
            GL.PopMatrix();

            glUserControl11.SwapBuffers();
        }
    }
}
