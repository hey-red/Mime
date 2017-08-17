using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HeyRed.Mime
{
    public static class MagicUtils
    {
        private static bool IsOSX() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        private static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static string GetDefaultMagicPath()
        {
            string home = Environment.GetEnvironmentVariable(IsLinux() || IsOSX() ? "HOME" : "USERPROFILE");
            if (home != null)
            {
                var pgkVer = Assembly
                    .Load(new AssemblyName("Mime"))
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    .InformationalVersion;

                var runtime = "win-x64";
                if (IsLinux()) runtime = "linux-x64";
                else if (IsOSX()) runtime = "osx-x64";

                var magicPath = Path.Combine(home, ".nuget/packages/mime", pgkVer, "runtimes", runtime, "native/magic.mgc");
                if (File.Exists(magicPath)) return magicPath;
            }
            return null;
        }
    }
}
