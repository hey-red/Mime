using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HeyRed.Mime
{
    public class Magic : IDisposable
    {
        private readonly IntPtr _magic;

        public static int Version => MagicNative.magic_version();

        private string LastError
        {
            get
            {
                var err = Marshal.PtrToStringAnsi(MagicNative.magic_error(_magic));
                if (err == null) return err;
                return char.ToUpper(err[0]) + err.Substring(1);
            }
        }

        public Magic(MagicOpenFlags flags, string dbPath = null)
        {
            _magic = MagicNative.magic_open(flags);
            if (_magic == IntPtr.Zero)
            {
                throw new MagicException(LastError, "Cannot create magic cookie.");
            }

            if (dbPath == null)
            {
                dbPath = MagicUtils.GetDefaultMagicPath();
            }

            if (MagicNative.magic_load(_magic, dbPath) != 0)
            {
                throw new MagicException(LastError, "Cannot load magic database file.");
            }
        }

        public string Read(string filePath)
        {
            ThrowIfDisposed();

            var str = Marshal.PtrToStringAnsi(MagicNative.magic_file(_magic, filePath));
            if (str == null)
            {
                throw new MagicException(LastError);
            }

            return str;
        }

        public string Read(byte[] buffer, int bufferSize)
        {
            ThrowIfDisposed();

            var str = Marshal.PtrToStringAnsi(MagicNative.magic_buffer(_magic, buffer, bufferSize));
            if (str == null)
            {
                throw new MagicException(LastError);
            }
            return str;
        }

        public string Read(Stream stream, int bufferSize)
        {
            ThrowIfDisposed();

            byte[] buffer = new byte[bufferSize];
            int offset = 0;
            while (offset < bufferSize)
            {
                int read = stream.Read(buffer, offset, bufferSize - offset);
                if (read == 0) break;
                offset += read;
            }

            if (stream.CanSeek) stream.Position = 0;

            return Read(buffer, bufferSize);
        }

        public MagicOpenFlags GetFlags() => MagicNative.magic_getflags(_magic);

        public void SetFlags(MagicOpenFlags flags) 
        {
            int result = MagicNative.magic_setflags(_magic, flags);
            if (result == -1)
            {
                throw new MagicException("Cannot set magic flags. Utime/Utimes not supported.");
            }
        }

        public bool IsValidDatabase(string dbPath = null) => MagicNative.magic_check(_magic, dbPath) > -1;

        #region IDisposable support
        private bool _disposed = false;

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        private void DoDispose() => MagicNative.magic_close(_magic);

        ~Magic() => DoDispose();

        public void Dispose()
        {
            if (_disposed) return;

            DoDispose();

            _disposed = true;

            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
