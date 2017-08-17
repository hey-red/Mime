using System;
using System.IO;
using System.Reflection;

namespace MimeTests
{
    public static class ResourceUtils
    {
        public static string GetFileFixture =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "test.jpeg");

        public static string GetMagicFilePath => 
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "magic.mgc");
    }
}
