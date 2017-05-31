using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HeyRed.Mime
{
    public static class MagicUtils
    {
        private static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static string GetDefaultMagicPath()
        {
            if (IsLinux())
            {
                var home = Environment.GetEnvironmentVariable("HOME");
                var pgkVer = Assembly
                    .Load(new AssemblyName("Mime"))
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                    .InformationalVersion; // FIXME: Just parse "Location"?
                // TODO: Use platform ENV
                return Path.Combine(home, ".nuget/packages/mime", pgkVer, "runtimes/linux-x64/native/magic.mgc");
            }
            return null;
        }
    }
}
