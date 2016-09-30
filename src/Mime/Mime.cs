using System;
using System.IO;

namespace HeyRed.MimeGuesser
{
    public static class Mime
    {
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

            using (var magic = new Magic(
                MagicOpenFlags.MAGIC_ERROR | 
                MagicOpenFlags.MAGIC_MIME_TYPE))
            {
                return magic.Read(filePath);
            }
        }

        /// <summary>
        /// Get mime type from bytes buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>Mime type as string</returns>
        public static string GuessMimeType(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            using (var magic = new Magic(
                MagicOpenFlags.MAGIC_ERROR |
                MagicOpenFlags.MAGIC_MIME_TYPE))
            {
                return magic.Read(buffer);
            }
        }

        /// <summary>
        /// Get mime type from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>Mime type as string</returns>
        public static string GuessMimeType(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            using (var magic = new Magic(
                MagicOpenFlags.MAGIC_ERROR |
                MagicOpenFlags.MAGIC_MIME_TYPE))
            {
                return magic.Read(stream);
            }
        }

        /// <summary>
        /// Get file extension from path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>First file extension as string</returns>
        public static string GuessExtension(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            using (var magic = new Magic(
                MagicOpenFlags.MAGIC_ERROR |
                MagicOpenFlags.MAGIC_EXTENSION))
            {
                return magic.Read(filePath).Split('/')[0];
            }
        }

        /// <summary>
        /// Get file extension from bytes buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>First file extension as string</returns>
        public static string GuessExtension(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            using (var magic = new Magic(
                MagicOpenFlags.MAGIC_ERROR |
                MagicOpenFlags.MAGIC_EXTENSION))
            {
                return magic.Read(buffer).Split('/')[0];
            }
        }

        /// <summary>
        /// Get file extension from stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>First file extension as string</returns>
        public static string GuessExtension(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            using (var magic = new Magic(
                MagicOpenFlags.MAGIC_ERROR |
                MagicOpenFlags.MAGIC_EXTENSION))
            {
                return magic.Read(stream).Split('/')[0];
            }
        }
    }
}
