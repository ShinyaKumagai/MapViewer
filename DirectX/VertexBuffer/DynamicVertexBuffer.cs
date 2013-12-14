using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Graphics.DirectX.Vertex;

namespace Graphics.DirectX.VertexBuffer
{
    using D3D = SlimDX.Direct3D9;

    /// <summary>
    /// 頂点バッファを操作するためのクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicVertexBuffer<T> : IDynamicVertexBuffer<T>
        where T : struct
    {
        #region Private fields

        /// <summary>
        /// デフォルトのバッファのサイズ
        /// </summary>
        private static readonly int DefaultBufferSize = 32;

        /// <summary>
        /// 
        /// </summary>
        private D3D.Device _device;

        /// <summary>
        /// 頂点バッファ
        /// </summary>
        private D3D.VertexBuffer _vertexBuffer;

        /// <summary>
        /// 頂点宣言
        /// </summary>
        private IDeclarationContainer _declarationContainer;

        /// <summary>
        /// 頂点配列
        /// </summary>
        private IList<T> _vertices;

        /// <summary>
        /// 頂点バッファのサイズ
        /// </summary>
        private int _bufferSize;

        /// <summary>
        /// 変更をコミットするかどうか
        /// </summary>
        private bool _shouldCommit;

        #endregion

        #region Public properties

        #region IDynamicVertexBuffer

        public int VertexCount
        {
            get
            {
                return _vertices.Count;
            }
        }

        #endregion

        #endregion

        #region Constructor and Destrcutor

        /// <summary>
        /// 新しいインスタンスを作成する
        /// </summary>
        /// <param name="device">D3Dデバイス</param>
        /// <param name="declarationContainer">頂点宣言</param>

        public DynamicVertexBuffer(D3D.Device device, IDeclarationContainer declarationContainer)
        {
            if (device == null)
            {
                throw new ArgumentNullException("device");
            }
            if (declarationContainer == null)
            {
                throw new ArgumentException("declaration");
            }

            _device = device;
            _declarationContainer = declarationContainer;
            _vertices = new List<T>();
            _bufferSize = 0;
            _shouldCommit = false;
        }

        #endregion

        #region Public methods

        #region IDisposable

        public void Dispose()
        {
            if (_vertexBuffer != null)
            {
                _vertexBuffer.Dispose();
            }
            if (_declarationContainer.VertexDeclaration != null)
            { 
                _declarationContainer.VertexDeclaration.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IDynamicVertexBuffer

        public void SetStreamSource(D3D.Device device)
        {
            device.SetStreamSource(0, _vertexBuffer, 0, _declarationContainer.SizeInBytes);
            device.VertexDeclaration = _declarationContainer.VertexDeclaration;
        }

        public void Commit()
        {
            if (_shouldCommit)
            {
                FillBuffer();
                _shouldCommit = false;
            }
        }

        public void Add(T vertex)
        {
            _vertices.Add(vertex);
            // 頂点配列の数がバッファのサイズを超えた場合
            if (_vertices.Count > _bufferSize)
            {
                _bufferSize = (_bufferSize == 0) ?
                    DefaultBufferSize : _bufferSize * 2;
                // バッファのサイズを拡大する
                ResizeBuffer(_bufferSize * _declarationContainer.SizeInBytes);
            }
            _shouldCommit = true;
        }

        public void Add(T[] vertices)
        {
            foreach (var v in vertices)
            {
                Add(v);
            }
        }

        public void Clear()
        {
            _vertices.Clear();
        }

        #endregion

        #endregion

        #region Private methods

        private void ResizeBuffer(int sizeInBytes)
        {
            if (_vertexBuffer != null)
            {
                _vertexBuffer.Dispose();
            }

            _vertexBuffer = new D3D.VertexBuffer(
                _device,
                sizeInBytes,
                D3D.Usage.Dynamic | D3D.Usage.WriteOnly,
                D3D.VertexFormat.None,
                D3D.Pool.Default
            );
        }

        private void FillBuffer()
        {
            if (_vertexBuffer == null)
            {
                throw new NullReferenceException("vertexBuffer");
            }

            // 頂点配列を転送するためのストリームを取得する
            var stream = _vertexBuffer.Lock(0, 0, D3D.LockFlags.Discard);
            try
            {
                stream.WriteRange(_vertices.ToArray());
            }
            finally
            {
                // バッファへの転送を終える
                _vertexBuffer.Unlock();
            }
        }

        #endregion
    }
}
