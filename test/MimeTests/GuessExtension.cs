using HeyRed.Mime;

using System.IO;

using Xunit;

namespace MimeTests;

public class GuessExtension
{
    [Fact]
    public void GuessExtensionFromFilePath()
    {
        var expected = "jpeg";
        string actual = MimeGuesser.GuessExtension(ResourceUtils.GetJpegFileFixture);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessExtensionFromBuffer()
    {
        byte[] buffer = File.ReadAllBytes(ResourceUtils.GetJpegFileFixture);
        var expected = "jpeg";
        string actual = MimeGuesser.GuessExtension(buffer);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessExtensionFromStream()
    {
        using var stream = File.OpenRead(ResourceUtils.GetJpegFileFixture);
        string expected = "jpeg";
        string actual = MimeGuesser.GuessExtension(stream);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GuessExtensionFromFileInfo()
    {
        var expected = "jpeg";
        var fi = new FileInfo(ResourceUtils.GetJpegFileFixture);
        string actual = fi.GuessExtension();

        Assert.Equal(expected, actual);
    }
}