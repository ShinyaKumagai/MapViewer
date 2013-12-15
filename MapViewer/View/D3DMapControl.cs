using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapViewer.Provider;
using Graphics.DirectX.Primitive;
using MapViewer.Geometory;
using MapViewer.Geometory.DirectX;
using Graphics.DirectX.Vertex;
using Graphics.DirectX.Device;
using Graphics.DirectX.Camera;
using SlimDX.Direct3D9;
using SlimDX;
using System.Diagnostics;

namespace MapViewer.View
{
    /// <summary>
    /// Direct3D9を使用して地図を描画するコントロール
    /// </summary>
    public partial class D3DMapControl : UserControl, IOpenable, IClosable
    {
        #region Private fields

        /// <summary>
        /// D3D9デバイスコンテキスト
        /// </summary>
        private DeviceContext _context;

        /// <summary>
        /// 地図を構成する線のみのポリゴン
        /// </summary>
        private IList<LinePolygon> _linePolygons;

        /// <summary>
        /// スクリーン座標用のカメラ
        /// </summary>
        private ICamera2D _camera;

        #endregion

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        public D3DMapControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public mehods

        public void Open(IProvider<Polygon> provider)
        {
            // ロード中はカーソルを待機状態にする
            Cursor = Cursors.WaitCursor;

            // ファイルからGL用のラインポリゴンを作成する
            var polygons = new DXPolygonProvider(provider).Provide(ClientSize);
            CreateLinePolygons(polygons);

            // 終了時にカーソルを戻す
            Cursor = Cursors.Default;
            // コントロールを再描画する
            Invalidate();
        }

        #region IClosable

        public void Close()
        {
            if (_linePolygons == null)
            {
                return;
            }

            foreach (var polyline in _linePolygons)
            {
                polyline.Dispose();
            }
        }

        #endregion

        #endregion

        #region Private methods

        private void CreateLinePolygons(IList<DXPolygon> polygons)
        {
            _linePolygons = new List<LinePolygon>(polygons.Count);

            // 作成したポリゴンをO頂点配列に変換する
            foreach (var polygon in polygons)
            {
                var vertices = polygon.Select(p =>
                {
                    return new VertexPosition()
                    {
                        Position = new SlimDX.Vector2(p.X, p.Y),
                    };
                });
                // 頂点配列からポリゴンラインのVBOを作成する
                var linePolygon = new LinePolygon();
                linePolygon.CreateVertexBuffer(_context.Device, vertices.ToArray());

                _linePolygons.Add(linePolygon);
            }
        }


        #endregion

        #region Events

        private void OnLoad(object sender, EventArgs e)
        {
            var settings = new DeviceSettings
            {
                AdapterOrdinal = 0,
                CreationFlags = CreateFlags.HardwareVertexProcessing,
                Width = ClientSize.Width,
                Height = ClientSize.Height
            };
            _context = new DeviceContext(Handle, settings);
            _camera = new Camera2D(ClientSize);
            _linePolygons = new List<LinePolygon>();

            // 親フォームが閉じられたときに頂点バッファを破棄する
            ParentForm.FormClosed += (_s, _e) =>
            {
                foreach (var polyline in _linePolygons)
                {
                    polyline.Dispose();
                }
            };
        }

        private void OnPaintMap(object sender, PaintEventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();

            _camera.Update(_context.Device);

            _context.Device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, new Color4(0.0f, 0.0f, 0.0f), 1.0f, 0);
            _context.Device.SetRenderState(RenderState.Lighting, false);

            _context.Device.BeginScene();

            foreach (var polyline in _linePolygons)
            {
                polyline.Render(_context.Device);
            }

            _context.Device.EndScene();
            _context.Device.Present();

            Console.WriteLine("elapsedTime : {0}", stopwatch.Elapsed);
        }

        #endregion
    }
}
