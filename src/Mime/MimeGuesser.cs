using System;
using System.IO;

namespace HeyRed.Mime
{
    /// <summary>
    /// Static "facade" for <see cref="Magic"/>
    /// </summary>
    public static class MimeGuesser
    {
        /// <summary>
        /// Path to libmagic database file
        /// </summary>
        public static string MagicFilePath { get; set; } = null;

        /// <summary>
        /// Libmagic open flags for getting file type
        /// </summary>
        private static readonly MagicOpenFlags MagicMimeFlags = 
            MagicOpenFlags.MAGIC_ERROR | 
            MagicOpenFlags.MAGIC_MIME_TYPE |
            MagicOpenFlags.MAGIC_NO_CHECK_COMPRESS |
            MagicOpenFlags.MAGIC_NO_CHECK_ELF |
            MagicOpenFlags.MAGIC_NO_CHECK_APPTYPE |
            MagicOpenFlags.MAGIC_NO_CHECK_ENCODING;

        #region Guess mime type
        /// <summary>
        /// Get mime type from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Mime type as string</returns>
        public static string GuessMimeType(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            using (var magic = new Magic(MagicMimeFlags, MagicFilePath))
            {
                return magic.Read(filePath);
            }
        }

        /// <summary>
        /// Get mime type from bytes buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>Mime type as string</returns>
        public static string GuessMimeType(byte[] buffer, int size = 512)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            using (var magic = new Magic(MagicMimeFlags, MagicFilePath))
            {
                return magic.Read(buffer, size);
            }
        }

        /// <summary>
        /// Get mime type from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>Mime type as string</returns>
        public static string GuessMimeType(Stream stream, int size = 512)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            using (var magic = new Magic(MagicMimeFlags, MagicFilePath))
            {
                return magic.Read(stream, size);
            }
        }

        /// <summary>
        /// <see cref="GuessMimeType(string)"/>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns>Mime type as string</returns>
        public static string GuessMimeType(this FileInfo fi)
        {
            return GuessMimeType(fi.FullName);
        }
        #endregion

        #region Guess extension
        /// <summary>
        /// Get file extension from path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Extension as string</returns>
        public static string GuessExtension(string filePath)
        {
            return MimeTypesMap.GetExtension(GuessMimeType(filePath));
        }

        /// <summary>
        /// Get file extension from bytes buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>Extension as string</returns>
        public static string GuessExtension(byte[] buffer, int size = 512)
        {
            return MimeTypesMap.GetExtension(GuessMimeType(buffer, size));
        }

        /// <summary>
        /// Get file extension from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>Extension as string</returns>
        public static string GuessExtension(Stream stream, int size = 512)
        {
            return MimeTypesMap.GetExtension(GuessMimeType(stream, size));
        }

        /// <summary>
        /// <see cref="GuessExtension(string)"/>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns>Extension as string</returns>
        public static string GuessExtension(this FileInfo fi)
        {
            return GuessExtension(fi.FullName);
        }
        #endregion

        #region Guess file type
        /// <summary>
        /// Get file type from path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>FileType</returns>
        public static FileType GuessFileType(string filePath)
        {
            var mime = GuessMimeType(filePath);
            var ext = MimeTypesMap.GetExtension(mime);
            return new FileType(mime, ext);
        }

        /// <summary>
        /// Get file type from bytes buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>FileType</returns>
        public static FileType GuessFileType(byte[] buffer, int size = 512)
        {
            var mime = GuessMimeType(buffer, size);
            var ext = MimeTypesMap.GetExtension(mime);
            return new FileType(mime, ext);
        }

        /// <summary>
        /// Get file type from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>FileType</returns>
        public static FileType GuessFileType(Stream stream, int size = 512)
        {
            var mime = GuessMimeType(stream, size);
            var ext = MimeTypesMap.GetExtension(mime);
            return new FileType(mime, ext);
        }

        /// <summary>
        /// <see cref="GuessFileType(string)"/>
        /// </summary>
        /// <param name="fi"></param>
        /// <returns>FileType</returns>
        public static FileType GuessFileType(this FileInfo fi)
        {
            return GuessFileType(fi.FullName);
        }
        #endregion
    }
}
