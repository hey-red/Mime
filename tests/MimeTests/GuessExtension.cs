using HeyRed.Mime;
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

        [Fact]
        public void GuessExtensionFromFilePath()
        {
            string path = Path.Combine(_testPath, "test.jpeg");
            string expected = "jpeg";
            string actual = Mime.GuessExtension(path);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessExtensionFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(Path.Combine(_testPath, "test.jpeg"));
            string expected = "jpeg";
            string actual = Mime.GuessExtension(buffer);

            Assert.Equal(expected, actual);
        }
    }
}
