namespace HeyRed.Mime;

/// <summary>
/// Provides information about MIME type/file extension.
/// </summary>
/// <remarks>
/// Creates a new instance of <see cref="FileType"/>
/// </remarks>
/// <param name="mime"></param>
/// <param name="extension"></param>
public readonly struct FileType(string mime, string extension)
{
    /// <summary>
    /// The MIME type.
    /// More https://en.wikipedia.org/wiki/Media_type
    /// </summary>
    public string MimeType { get; } = mime;

    /// <summary>
    /// The file extension
    /// </summary>
    public string Extension { get; } = extension;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mimeType"></param>
    /// <param name="extension"></param>
    public void Deconstruct(out string mimeType, out string extension)
    {
        mimeType = MimeType;
        extension = Extension;
    }
}