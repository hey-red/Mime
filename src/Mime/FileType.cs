namespace HeyRed.MimeGuesser
{
    public struct FileType
    {
        public string MimeType { get; }
        public string Extension { get; }

        public FileType(string mime, string extension)
        {
            MimeType = mime;
            Extension = extension;
        }
    }
}
