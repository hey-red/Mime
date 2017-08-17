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
            var home = Environment.GetEnvironmentVariable(IsLinux() || IsOSX() ? "HOME" : "USERPROFILE");
            if (home != null)
            {
                var pgkVer = Assembly
                    .Load(new AssemblyName("Mime"))
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    .InformationalVersion;

                var magicPath = Path.Combine(home, ".nuget/packages/mime", pgkVer, "magic.mgc");
                if (File.Exists(magicPath)) return magicPath;
            }
            return null;
        }
    }
}
