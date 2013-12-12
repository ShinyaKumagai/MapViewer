using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapViewer.DirectX.Device
{
    using DX9Device = SlimDX.Direct3D9.Device;

    /// <summary>
    /// Provides creation and management functionality for a Direct3D9 rendering device and related objects.
    /// </summary>

    public class DeviceContext : IDisposable
    {
        #region Private fields

        /// <summary>
        /// 
        /// </summary>
        private Direct3D _direct3d;

        /// <summary>
        /// 
        /// </summary>
        private DeviceSettings _settings;

        #endregion

        #region Public properties

        /// <summary>
        /// 
        /// </summary>
        public DX9Device Device
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public PresentParameters PresentParameters
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceContext"/> class.
        /// </summary>
        /// <param name="handle">The window handle to associate with the device.</param>
        /// <param name="settings">The settings used to configure the device.</param>
        internal DeviceContext(IntPtr handle, DeviceSettings settings) {
            if (handle == IntPtr.Zero)
            {
                throw new ArgumentException("Value must be a valid window handle.", "handle");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            _settings = settings;
            _direct3d = new Direct3D();

            PresentParameters = CreatePresentParameters(handle, settings);
            Device = new DX9Device(_direct3d, settings.AdapterOrdinal, DeviceType.Hardware, handle, 
                settings.CreationFlags, PresentParameters);
        }

        #endregion

        #region Private methods

        private PresentParameters CreatePresentParameters(IntPtr handle, DeviceSettings settings)
        {
            return new PresentParameters()
            {
                BackBufferFormat = Format.X8R8G8B8,
                BackBufferCount = 1,
                BackBufferWidth = settings.Width,
                BackBufferHeight = settings.Height,
                Multisample = MultisampleType.None,
                SwapEffect = SwapEffect.Discard,
                EnableAutoDepthStencil = true,
                AutoDepthStencilFormat = Format.D16,
                PresentFlags = PresentFlags.DiscardDepthStencil,
                PresentationInterval = PresentInterval.Default,
                Windowed = true,
                DeviceWindowHandle = handle,
            };
 
        }

        #endregion
    }
}
