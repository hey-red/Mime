using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HeyRed.Mime
{
    /// <summary>
    /// Provides access to some libmagic methods
    /// </summary>
    public sealed class Magic : IDisposable
    {
        private static readonly object _magicLock = new();

        private readonly IntPtr _magic;

        /// <summary>
        /// Contains the version number of this library which is compiled
        /// into the shared library using the constant
        /// </summary>
        public static int Version => MagicNative.magic_version();

        private string LastError
        {
            get
            {
                var err = Marshal.PtrToStringAnsi(MagicNative.magic_error(_magic));
                return err != null ?
                    char.ToUpper(err[0]) + err.Substring(1) :
                    string.Empty;
            }
        }

        /// <summary>
        /// Creates a magic cookie and load database from given path
        /// </summary>
        /// <param name="flags"></param>
        /// <param name="dbPath"></param>
        public Magic(MagicOpenFlags flags, string? dbPath = null)
        {
            lock (_magicLock)
            {
                _magic = MagicNative.magic_open(flags);
                if (_magic == IntPtr.Zero)
                {
                    throw new MagicException(LastError, "Cannot create magic cookie.");
                }

                dbPath ??= MagicUtils.GetDefaultMagicPath();

                if (MagicNative.magic_load(_magic, dbPath) != 0)
                {
                    throw new MagicException(LastError, "Unable to load magic database file.");
                }
            }
        }

        /// <summary>
        /// Reads file from given path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>returns a textual description of the contents of file</returns>
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

        /// <summary>
        /// Reads contents from buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bufferSize"></param>
        /// <returns>returns a textual description of the contents of the buffer</returns>
        public string Read(byte[] buffer, int bufferSize)
        {
            ThrowIfDisposed();

            var length = buffer.Length < bufferSize ? buffer.Length : bufferSize;

            var str = Marshal.PtrToStringAnsi(MagicNative.magic_buffer(_magic, buffer, length));
            if (str == null)
            {
                throw new MagicException(LastError);
            }

            return str;
        }

        /// <summary>
        /// Reads contents from stream with buffer size limit
        /// </summary>
        /// <remarks>
        /// This method rewinds the stream if it's possible
        /// </remarks>
        /// <param name="stream"></param>
        /// <param name="bufferSize">in bytes</param>
        /// <returns>returns a textual description of the contents of the stream</returns>
        public string Read(Stream stream, int bufferSize)
        {
            ThrowIfDisposed();

            if (stream == null)
            {
                throw new ArgumentException(nameof(stream));
            }

            using var bufferMs = new MemoryStream(bufferSize);

            stream.CopyTo(bufferMs);

            if (stream.CanSeek) stream.Position = 0;

            return Read(bufferMs.ToArray(), bufferSize);
        }

        /// <summary>
        /// Returns a value representing current <see cref="MagicOpenFlags"/> set
        /// </summary>
        /// <returns></returns>
        public MagicOpenFlags GetFlags()
        {
            ThrowIfDisposed();

            return MagicNative.magic_getflags(_magic);
        }

        /// <summary>
        /// Sets the flags <see cref="MagicOpenFlags"/>
        /// Note that using both MIME flags together can also return extra information on the charset.
        /// </summary>
        /// <param name="flags"></param>
        public void SetFlags(MagicOpenFlags flags)
        {
            ThrowIfDisposed();

            if (MagicNative.magic_setflags(_magic, flags) < 0)
            {
                throw new MagicException("Utime/Utimes not supported.");
            }
        }

        /// <summary>
        /// Gets various limits related to the magic library.
        /// <see cref="MagicParams"/>
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int GetParam(MagicParams param)
        {
            ThrowIfDisposed();

            if (MagicNative.magic_getparam(_magic, param, out int value) < 0)
            {
                throw new MagicException($"Invalid param \"{param}\".");
            }

            return value;
        }

        /// <summary>
        /// Sets various limits related to the magic library.
        /// <see cref="MagicParams"/>
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public void SetParam(MagicParams param, int value)
        {
            ThrowIfDisposed();

            if (MagicNative.magic_setparam(_magic, param, ref value) < 0)
            {
                throw new MagicException($"Invalid param \"{param}\".");
            }
        }

        /// <summary>
        /// Can be used to check the validity of entries
        /// in the colon separated database files
        /// </summary>
        /// <param name="dbPath"></param>
        public void CheckDatabase(string? dbPath = null)
        {
            ThrowIfDisposed();

            if (dbPath == null)
            {
                dbPath = MagicUtils.GetDefaultMagicPath();
            }

            int result = MagicNative.magic_check(_magic, dbPath);
            if (result < 0)
            {
                throw new MagicException(LastError);
            }
        }

        // TODO: Tests
        /// <summary>
        /// Can be used to compile the colon separated list of database files
        /// </summary>
        /// <param name="dbPath"></param>
        public void CompileDatabase(string? dbPath = null)
        {
            ThrowIfDisposed();

            if (MagicNative.magic_compile(_magic, dbPath ?? "") < 0)
            {
                throw new MagicException(LastError);
            }
        }

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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        ~Magic() => DoDispose();

        /// <summary>
        /// Cleanups all unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_disposed) return;

            DoDispose();

            _disposed = true;

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable support
    }
}