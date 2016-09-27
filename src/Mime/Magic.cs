using System;
using System.Runtime.InteropServices;

namespace HeyRed.MimeGuesser
{
    public class Magic : IDisposable
    {
        private IntPtr _magic;

        public Magic(MagicOpenFlags flags, string dbPath = null)
        {
            _magic = MagicNative.magic_open(flags);
            if (_magic == IntPtr.Zero)
            {
                throw new MagicException("Cannot create magic cookie.");
            }
            if (MagicNative.magic_load(_magic, dbPath) == -1 && 
                dbPath != null)
            {
                throw new MagicException(GetLastError());
            }
        }

        public string Read(string filePath)
        {
            var str = Marshal.PtrToStringAnsi(MagicNative.magic_file(_magic, filePath));
            if (str == null)
            {
                throw new MagicException(GetLastError());
            }
            return str;
        }

        public string Read(byte[] buffer)
        {
            var str = Marshal.PtrToStringAnsi(MagicNative.magic_buffer(_magic, buffer, buffer.Length));
            if (str == null)
            {
                throw new MagicException(GetLastError());
            }
            return str;
        }

        private string GetLastError()
        {
            var err = Marshal.PtrToStringAnsi(MagicNative.magic_error(_magic));
            return char.ToUpper(err[0]) + err.Substring(1);
        }

        #region IDisposable support
        ~Magic()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_magic != IntPtr.Zero)
            {
                MagicNative.magic_close(_magic);
                _magic = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
