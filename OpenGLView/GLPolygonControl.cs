using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using Graphics.OpenGL.VBO;
using Graphics.OpenGL.Vertex;
using Graphics.OpenGL.Camera;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace ViewTest
{
    public partial class GLPolygonControl : GLControl
    {
        private VertexBufferObject<VertexPositionColor> _vbo;
        private Camera2D _camera;


        public GLPolygonControl()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            MakeCurrent();

            ParentForm.FormClosed += (_s, _e) =>
                {
                    if (_vbo != null)
                    {
                        _vbo.Dispose();
                    }
                };

            try
            {
                // 背景は白色で塗りつぶす
                GL.ClearColor(Color.Black);

                _camera = new Camera2D();
                _camera.ClipSize = ClientSize;
                GL.Viewport(ClientRectangle);

                var dec = new VertexPositionColor.Declaration();
                _vbo = new VertexBufferObject<VertexPositionColor>(dec);
                _vbo.Generate(new VertexPositionColor[] { 
                    new VertexPositionColor()
                    {
                        Position = new Vector2(0, 0),
                        Color = new Color4(1f, 1f, 1f, 1f),
                    },
                    new VertexPositionColor()
                    {
                        Position = new Vector2(0, 100),
                        Color = new Color4(1f, 1f, 1f, 1f),
                    },
                    new VertexPositionColor()
                    {
                        Position = new Vector2(100, 100),
                        Color = new Color4(1f, 1f, 1f, 1f),
                    },
                    new VertexPositionColor()
                    {
                        Position = new Vector2(100, 50),
                        Color = new Color4(1f, 1f, 1f, 1f),
                    },
                    new VertexPositionColor()
                    {
                        Position = new Vector2(150, 50),
                        Color = new Color4(0f, 0f, 0f, 0f),
                    },
                   new VertexPositionColor()
                    {
                        Position = new Vector2(150, 0),
                        Color = new Color4(0f, 0f, 0f, 0f),
                    },
                });

            } catch (Exception)
            {
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                GL.Clear(ClearBufferMask.ColorBufferBit);

                // 射影行列を更新する
                _camera.Update();

                // 行列をジオメトリ描画用に変更する
                GL.MatrixMode(MatrixMode.Modelview);
                // 線は赤色で描画する
                GL.Color4(Color.Red);
                GL.PushMatrix();
                {
                    _vbo.Bind();

                    GL.DrawArrays(BeginMode.TriangleFan, 0, _vbo.VertexCount);

                    _vbo.Unbind();
                }
                GL.PopMatrix();

                // 画面に反映させる。
                SwapBuffers();
            }
            catch (Exception)
            {
            }

            base.OnPaint(e);
        }
    }
}
