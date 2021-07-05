using System;

namespace HeyRed.Mime
{
    [Flags]
    public enum MagicOpenFlags
    {
        // From LIBMAGIC(3) man.

        /// <summary>
        /// No special handling.
        /// </summary>
        MAGIC_NONE = 0x000000,

        /// <summary>
        /// Print debugging messages to stderr.
        /// </summary>
        MAGIC_DEBUG = 0x000001,

        /// <summary>
        /// If the file queried is a symlink, follow it.
        /// </summary>
        MAGIC_SYMLINK = 0x000002,

        /// <summary>
        /// If the file is compressed, unpack it and look at the contents.
        /// </summary>
        MAGIC_COMPRESS = 0x000004,

        /// <summary>
        /// If the file is a block or character special device, then
        /// open the device and try to look in its contents.
        /// </summary>
        MAGIC_DEVICES = 0x000008,

        /// <summary>
        /// Return a MIME type string, instead of a textual description.
        /// </summary>
        MAGIC_MIME_TYPE = 0x000010,

        /// <summary>
        /// Return all matches, not just the first.
        /// </summary>
        MAGIC_CONTINUE = 0x000020,

        /// <summary>
        /// Check the magic database for consistency and print warnings to stderr.
        /// </summary>
        MAGIC_CHECK = 0x000040,

        /// <summary>
        /// On systems that support utime(3) or utimes(2), attempt to
        /// preserve the access time of files analysed.
        /// </summary>
        MAGIC_PRESERVE_ATIME = 0x000080,

        /// <summary>
        /// Don't translate unprintable characters to a \ooo octal representation.
        /// </summary>
        MAGIC_RAW = 0x000100,

        /// <summary>
        /// Treat operating system errors while trying to open files
        /// and follow symlinks as real errors, instead of printing
        /// them in the magic buffer.
        /// </summary>
        MAGIC_ERROR = 0x000200,

        /// <summary>
        /// Return a MIME encoding, instead of a textual description.
        /// </summary>
        MAGIC_MIME_ENCODING = 0x000400,

        /// <summary>
        /// A shorthand for MAGIC_MIME_TYPE | MAGIC_MIME_ENCODING.
        /// </summary>
        MAGIC_MIME = (MAGIC_MIME_TYPE | MAGIC_MIME_ENCODING),

        /// <summary>
        /// Return the Apple creator and type.
        /// </summary>
        MAGIC_APPLE = 0x000800,

        /// <summary>
        /// Return a slash-separated list of extensions for this file type.
        /// </summary>
        MAGIC_EXTENSION = 0x1000000,

        /// <summary>
        /// Don't report on compression, only report about the uncompressed data.
        /// </summary>
        MAGIC_COMPRESS_TRANSP = 0x200000,

        /// <summary>
        /// A shorthand for (MAGIC_EXTENSION|MAGIC_MIME|MAGIC_APPLE)
        /// </summary>
        MAGIC_NODESC = (MAGIC_EXTENSION | MAGIC_MIME | MAGIC_APPLE),

        /// <summary>
        /// Don't look inside compressed files.
        /// </summary>
        MAGIC_NO_CHECK_COMPRESS = 0x001000,

        /// <summary>
        /// Don't examine tar files.
        /// </summary>
        MAGIC_NO_CHECK_TAR = 0x002000,

        /// <summary>
        /// Don't consult magic files.
        /// </summary>
        MAGIC_NO_CHECK_SOFT = 0x004000,

        /// <summary>
        /// Don't check for EMX application type (only on EMX).
        /// </summary>
        MAGIC_NO_CHECK_APPTYPE = 0x008000,

        /// <summary>
        /// Don't print ELF details.
        /// </summary>
        MAGIC_NO_CHECK_ELF = 0x010000,

        /// <summary>
        /// Don't check for various types of text files.
        /// </summary>
        MAGIC_NO_CHECK_TEXT = 0x020000,

        /// <summary>
        /// Don't get extra information on MS Composite Document Files.
        /// </summary>
        MAGIC_NO_CHECK_CDF = 0x040000,

        /// <summary>
        /// Don't check for CSV files
        /// </summary>
        MAGIC_NO_CHECK_CSV = 0x080000,

        /// <summary>
        /// Don't look for known tokens inside ascii files.
        /// </summary>
        MAGIC_NO_CHECK_TOKENS = 0x100000,

        /// <summary>
        /// Don't check text encodings.
        /// </summary>
        MAGIC_NO_CHECK_ENCODING = 0x200000,

        /// <summary>
        ///  Don't check for JSON files
        /// </summary>
        MAGIC_NO_CHECK_JSON = 0x400000,

        /// <summary>
        /// No built-in tests; only consult the magic file
        /// </summary>
        MAGIC_NO_CHECK_BUILTIN =
            MAGIC_NO_CHECK_COMPRESS |
            MAGIC_NO_CHECK_TAR |
            MAGIC_NO_CHECK_SOFT |
            MAGIC_NO_CHECK_APPTYPE |
            MAGIC_NO_CHECK_ELF |
            MAGIC_NO_CHECK_TEXT |
            MAGIC_NO_CHECK_CSV |
            MAGIC_NO_CHECK_CDF |
            MAGIC_NO_CHECK_TOKENS |
            MAGIC_NO_CHECK_ENCODING |
            MAGIC_NO_CHECK_JSON,
    }
}