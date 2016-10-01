using HeyRed.MimeGuesser;
using System;
using System.IO;
using Xunit;

namespace MimeTests
{
    public class GuessMime
    {
        #if !NET451
        private static readonly string _testPath = Path.Combine(AppContext.BaseDirectory, "TestData");
        #else
        private static readonly string _testPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");
        #endif

        private static readonly string _filePath = Path.Combine(_testPath, "test.jpeg");

        [Fact]
        public void GuessMimeFromFilePath()
        {
            string expected = "image/jpeg";
            string actual = Mime.GuessMimeType(_filePath);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(_filePath);
            string expected = "image/jpeg";
            string actual = Mime.GuessMimeType(buffer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromStream()
        {
            using (var stream = File.OpenRead(_filePath))
            {
                string expected = "image/jpeg";
                string actual = Mime.GuessMimeType(stream);

                Assert.Equal(expected, actual);
            }
        }
    }
}
