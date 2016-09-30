using HeyRed.MimeGuesser;
using System;
using System.IO;
using Xunit;

namespace MimeTests
{
    public class GuessExtension
    {
        #if !NET451
        private static readonly string _testPath = Path.Combine(AppContext.BaseDirectory, "TestData");
        #else
        private static readonly string _testPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");
        #endif

        private static readonly string _filePath = Path.Combine(_testPath, "test.jpeg");

        [Fact]
        public void GuessExtensionFromFilePath()
        {
            string expected = "jpeg";
            string actual = Mime.GuessExtension(_filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessExtensionFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(_filePath);
            string expected = "jpeg";
            string actual = Mime.GuessExtension(buffer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessExtensionFromStream()
        {
            using (var stream = File.OpenRead(_filePath))
            {
                string expected = "jpeg";
                string actual = Mime.GuessExtension(stream);

                Assert.Equal(expected, actual);
            }
        }
    }
}
