using System.IO;

using HeyRed.Mime;

using Xunit;

namespace MimeTests
{
    public class GuessFileType
    {
        [Fact]
        public void GuessFileTypeFromFilePath()
        {
            var expected = new FileType("image/jpeg", "jpeg");
            FileType actual = MimeGuesser.GuessFileType(ResourceUtils.GetFileFixture);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessFileTypeFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(ResourceUtils.GetFileFixture);
            var expected = new FileType("image/jpeg", "jpeg");
            FileType actual = MimeGuesser.GuessFileType(buffer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessFileTypeFromStream()
        {
            using var stream = File.OpenRead(ResourceUtils.GetFileFixture);
            var expected = new FileType("image/jpeg", "jpeg");
            FileType actual = MimeGuesser.GuessFileType(stream);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessFileTypeFromFileInfo()
        {
            var expected = new FileType("image/jpeg", "jpeg");
            var fi = new FileInfo(ResourceUtils.GetFileFixture);
            FileType actual = fi.GuessFileType();

            Assert.Equal(expected, actual);
        }
    }
}
