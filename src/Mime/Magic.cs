using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HeyRed.MimeGuesser
{
    public class Magic : IDisposable
    {
        private IntPtr _magic;

        public static int Version
        {
            get { return MagicNative.magic_version(); }
        }

        private string LastError
        {
            get
            {
                var err = Marshal.PtrToStringAnsi(MagicNative.magic_error(_magic));
                return char.ToUpper(err[0]) + err.Substring(1);
            }
        }

        public Magic(MagicOpenFlags flags, string dbPath = null)
        {
            _magic = MagicNative.magic_open(flags);
            if (_magic == IntPtr.Zero)
            {
                throw new MagicException("Cannot create magic cookie.");
            }
            if (MagicNative.magic_load(_magic, dbPath) != 0)
            {
                throw new MagicException(LastError);
            }
        }

        public string Read(string filePath)
        {
            var str = Marshal.PtrToStringAnsi(MagicNative.magic_file(_magic, filePath));
            if (str == null)
            {
                throw new MagicException(LastError);
            }
            return str;
        }

        public string Read(byte[] buffer, int size = 512)
        {
            var str = Marshal.PtrToStringAnsi(MagicNative.magic_buffer(_magic, buffer, size));
            if (str == null)
            {
                throw new MagicException(LastError);
            }
            return str;
        }

        public string Read(Stream stream, int size = 512)
        {
            byte[] buffer = new byte[size];
            int offset = 0;
            while (offset < size)
            {
                int read = stream.Read(buffer, offset, size - offset);
                if (read == 0) break;
                offset += read;
            }
            stream.Position = 0;
            return Read(buffer, size);
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
