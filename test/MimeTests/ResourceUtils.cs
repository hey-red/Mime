using System;
using System.IO;

namespace MimeTests
{
    public static class ResourceUtils
    {
        public static string GetFileFixture =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "test.jpeg");
    }
}
