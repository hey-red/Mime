using HeyRed.Mime;
using System.IO;
using Xunit;

namespace MimeTests
{
    public class GuessFileType
    {
        public GuessFileType() =>
            MimeGuesser.MagicFilePath = ResourceUtils.GetMagicFilePath;

        [Fact]
        public void GuessFileTypeFromFilePath()
        {
            FileType expected = new FileType("image/jpeg", "jpeg");
            FileType actual = MimeGuesser.GuessFileType(ResourceUtils.GetFileFixture);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessFileTypeFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(ResourceUtils.GetFileFixture);
            FileType expected = new FileType("image/jpeg", "jpeg");
            FileType actual = MimeGuesser.GuessFileType(buffer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessFileTypeFromStream()
        {
            using (var stream = File.OpenRead(ResourceUtils.GetFileFixture))
            {
                FileType expected = new FileType("image/jpeg", "jpeg");
                FileType actual = MimeGuesser.GuessFileType(stream);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void GuessFileTypeFromFileInfo()
        {
            FileType expected = new FileType("image/jpeg", "jpeg");
            var fi = new FileInfo(ResourceUtils.GetFileFixture);
            FileType actual = fi.GuessFileType();

            Assert.Equal(expected, actual);
        }
    }
}
