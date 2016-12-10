using HeyRed.MimeGuesser;
using System.IO;
using Xunit;

namespace MimeTests
{
    public class GuessFileType
    {
        [Fact]
        public void GuessFileTypeFromFilePath()
        {
            FileType expected = new FileType("image/jpeg", "jpeg");
            FileType actual = Mime.GuessFileType(ResourceUtils.TestDataPath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessFileTypeFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(ResourceUtils.TestDataPath);
            FileType expected = new FileType("image/jpeg", "jpeg");
            FileType actual = Mime.GuessFileType(buffer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessFileTypeFromStream()
        {
            using (var stream = File.OpenRead(ResourceUtils.TestDataPath))
            {
                FileType expected = new FileType("image/jpeg", "jpeg");
                FileType actual = Mime.GuessFileType(stream);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void GuessFileTypeFromFileInfo()
        {
            FileType expected = new FileType("image/jpeg", "jpeg");
            var fi = new FileInfo(ResourceUtils.TestDataPath);
            FileType actual = fi.GuessFileType();

            Assert.Equal(expected, actual);
        }
    }
}
