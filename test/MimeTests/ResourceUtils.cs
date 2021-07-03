using System;
using System.IO;

namespace MimeTests
{
    public static class ResourceUtils
    {
        public static string GetJpegFileFixture =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "test.jpeg");

        public static string GetTextFileFixture =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", ".editorconfig");
    }
}
