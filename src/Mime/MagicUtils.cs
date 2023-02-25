using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HeyRed.Mime;

internal static class MagicUtils
{
    private const string MAGIC_DB_NAME = "magic.mgc";

    private static string GetCurrentPlatform()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return "win";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return "linux";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return RuntimeInformation.ProcessArchitecture == Architecture.Arm64 ?
                "osx.13" :
                "osx";
        }

        throw new PlatformNotSupportedException();
    }

    public static string? GetDefaultMagicPath()
    {
        string assemblyLocation = typeof(MagicUtils).GetTypeInfo().Assembly.Location;
        string currentPath = assemblyLocation.Replace("Mime.dll", "");

        string magicDbPath = Path.Combine(currentPath, MAGIC_DB_NAME);

        // Find inside current directory
        if (File.Exists(magicDbPath))
        {
            return magicDbPath;
        }

        var rid = GetCurrentPlatform();
        var architecture = RuntimeInformation.ProcessArchitecture.ToString().ToLower();

        magicDbPath = Path.Combine(currentPath, $"runtimes/{rid}-{architecture}/native/", MAGIC_DB_NAME);

        // Find inside runtimes directory
        if (File.Exists(magicDbPath))
        {
            return magicDbPath;
        }

        return null;
    }
}