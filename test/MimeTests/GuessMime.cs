using System.IO;

using HeyRed.Mime;

using Xunit;

namespace MimeTests
{
    public class GuessMime
    {
        [Fact]
        public void GuessMimeFromFilePath()
        {
            var expected = "image/jpeg";
            string actual = MimeGuesser.GuessMimeType(ResourceUtils.GetFileFixture);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(ResourceUtils.GetFileFixture);
            var expected = "image/jpeg";
            string actual = MimeGuesser.GuessMimeType(buffer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromStream()
        {
            using var stream = File.OpenRead(ResourceUtils.GetFileFixture);
            var expected = "image/jpeg";
            string actual = MimeGuesser.GuessMimeType(stream);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromFileInfo()
        {
            var expected = "image/jpeg";
            var fi = new FileInfo(ResourceUtils.GetFileFixture);
            string actual = fi.GuessMimeType();

            Assert.Equal(expected, actual);
        }
    }
}
