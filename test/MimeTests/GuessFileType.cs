using HeyRed.Mime;

using System.IO;

using Xunit;

namespace MimeTests;

public class GuessFileType
{
    [Fact]
    public void GuessFileTypeFromFilePath()
    {
        var expected = new FileType("image/jpeg", "jpeg");
        FileType actual = MimeGuesser.GuessFileType(ResourceUtils.GetJpegFileFixture);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessFileTypeFromBuffer()
    {
        byte[] buffer = File.ReadAllBytes(ResourceUtils.GetJpegFileFixture);
        var expected = new FileType("image/jpeg", "jpeg");
        FileType actual = MimeGuesser.GuessFileType(buffer);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessFileTypeFromStream()
    {
        using var stream = File.OpenRead(ResourceUtils.GetJpegFileFixture);
        var expected = new FileType("image/jpeg", "jpeg");
        FileType actual = MimeGuesser.GuessFileType(stream);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessFileTypeFromFileInfo()
    {
        var expected = new FileType("image/jpeg", "jpeg");
        var fi = new FileInfo(ResourceUtils.GetJpegFileFixture);
        FileType actual = fi.GuessFileType();

        Assert.Equal(expected, actual);
    }
}