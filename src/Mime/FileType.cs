namespace HeyRed.Mime
{
    /// <summary>
    /// Provides information about MIME type/file extension.
    /// </summary>
    public struct FileType
    {
        /// <summary>
        /// The MIME type.
        /// More https://en.wikipedia.org/wiki/Media_type
        /// </summary>
        public string MimeType { get; }

        /// <summary>
        /// The file extension
        /// </summary>
        public string Extension { get; }

        /// <summary>
        /// Creates a new instance of <see cref="FileType"/>
        /// </summary>
        /// <param name="mime"></param>
        /// <param name="extension"></param>
        public FileType(string mime, string extension)
        {
            MimeType = mime;
            Extension = extension;
        }
    }
}