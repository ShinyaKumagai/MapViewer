using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Graphics.DirectX.Device;
using SlimDX.Direct3D9;
using Graphics.DirectX.Primitive;
using Graphics.DirectX.Camera;
using SlimDX;

namespace ViewTest
{
    public partial class D3DUserControl : UserControl
    {
        private DeviceContext _deviceContext;
        private Quad2D _quad;
        private Camera2D _camera;

        public D3DUserControl()
        {
            InitializeComponent();
        }

        private void D3DUserControl_Load(object sender, EventArgs e)
        {
            var settings = new DeviceSettings
            {
                AdapterOrdinal = 0,
                CreationFlags = CreateFlags.HardwareVertexProcessing,
                Width = ClientSize.Width,
                Height = ClientSize.Height
            };
            _deviceContext = new DeviceContext(Handle, settings);

            _camera = new Camera2D(ClientSize);
            _quad = new Quad2D(100, 100);
            _quad.CreateVertexBuffer(_deviceContext.Device);

            ParentForm.FormClosed += (_s, _e) =>
            {
                _quad.Dispose();
            };

        }

        private void D3DUserControl_Paint(object sender, PaintEventArgs e)
        {
            _camera.Update(_deviceContext.Device);

            _deviceContext.Device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, new Color4(0.3f, 0.3f, 0.3f), 1.0f, 0);
            _deviceContext.Device.SetRenderState(RenderState.Lighting, false);

            _deviceContext.Device.BeginScene();

            _quad.Render(_deviceContext.Device);

            _deviceContext.Device.EndScene();
            _deviceContext.Device.Present();
        }
    }
}
