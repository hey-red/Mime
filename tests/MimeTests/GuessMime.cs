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

        [Fact]
        public void GuessMimeFromFilePath()
        {
            string path = Path.Combine(_testPath, "test.jpeg");
            string expected = "image/jpeg";
            string actual = Mime.GuessMimeType(path);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GuessMimeFromBuffer()
        {
            byte[] buffer = File.ReadAllBytes(Path.Combine(_testPath, "test.jpeg"));
            string expected = "image/jpeg";
            string actual = Mime.GuessMimeType(buffer);

            Assert.Equal(expected, actual);
        }
    }
}
