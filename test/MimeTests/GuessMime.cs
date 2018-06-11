using HeyRed.Mime;
using System.IO;
using System.Net.Http;
using Xunit;

namespace MimeTests
{
    public class GuessMime
    {
        public GuessMime() =>
            MimeGuesser.MagicFilePath = ResourceUtils.GetMagicFilePath;

        [Fact]
        public void GuessMimeFromFilePath()
        {
            string expected = "image/jpeg";
            string actual = MimeGuesser.GuessMimeType(ResourceUtils.GetFileFixture);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(ResourceUtils.GetFileFixture);
            string expected = "image/jpeg";
            string actual = MimeGuesser.GuessMimeType(buffer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromStream()
        {
            using (var stream = File.OpenRead(ResourceUtils.GetFileFixture))
            {
                string expected = "image/jpeg";
                string actual = MimeGuesser.GuessMimeType(stream);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void GuessMimeFromFileInfo()
        {
            string expected = "image/jpeg";
            var fi = new FileInfo(ResourceUtils.GetFileFixture);
            string actual = fi.GuessMimeType();

            Assert.Equal(expected, actual);
        }
    }
}
