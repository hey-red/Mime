using System;
using System.IO;

namespace MimeTests
{
    public static class ResourceUtils
    {
        #if !NET45
        private static readonly string _testPath = Path.Combine(AppContext.BaseDirectory, "TestData");
        #else
        private static readonly string _testPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");
        #endif

        public static string TestDataPath {
            get { return Path.Combine(_testPath, "test.jpeg"); }
        }
    }
}
