using HeyRed.Mime;

using System.IO;

using Xunit;

namespace MimeTests;

public class GuessMime
{
    [Fact]
    public void GuessMimeFromFilePath()
    {
        var expected = "image/jpeg";
        string actual = MimeGuesser.GuessMimeType(ResourceUtils.GetJpegFileFixture);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessMimeFromBuffer()
    {
        byte[] buffer = File.ReadAllBytes(ResourceUtils.GetJpegFileFixture);
        var expected = "image/jpeg";
        string actual = MimeGuesser.GuessMimeType(buffer);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessMimeFromStream()
    {
        using var stream = File.OpenRead(ResourceUtils.GetJpegFileFixture);
        var expected = "image/jpeg";
        string actual = MimeGuesser.GuessMimeType(stream);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessMimeFromSmallTextStream()
    {
        using var stream = File.OpenRead(ResourceUtils.GetTextFileFixture);
        var expected = "text/plain";
        string actual = MimeGuesser.GuessMimeType(stream);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessMimeFromFileInfo()
    {
        var expected = "image/jpeg";
        var fi = new FileInfo(ResourceUtils.GetJpegFileFixture);
        string actual = fi.GuessMimeType();

        Assert.Equal(expected, actual);
    }
}