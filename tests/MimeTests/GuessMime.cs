using HeyRed.MimeGuesser;
using System.IO;
using Xunit;

namespace MimeTests
{
    public class GuessMime
    {
        [Fact]
        public void GuessMimeFromFilePath()
        {
            string expected = "image/jpeg";
            string actual = Mime.GuessMimeType(ResourceUtils.TestDataPath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(ResourceUtils.TestDataPath);
            string expected = "image/jpeg";
            string actual = Mime.GuessMimeType(buffer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromStream()
        {
            using (var stream = File.OpenRead(ResourceUtils.TestDataPath))
            {
                string expected = "image/jpeg";
                string actual = Mime.GuessMimeType(stream);

                Assert.Equal(expected, actual);
            }
        }
    }
}
