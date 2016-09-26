using System;

namespace HeyRed.Mime
{
    public static class Mime
    {
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
                //TODO: get from array
                return magic.Read(filePath);
            }
        }

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
                return magic.Read(buffer);
            }
        }
    }
}
