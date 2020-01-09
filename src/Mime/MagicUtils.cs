using System.IO;
using System.Reflection;

namespace HeyRed.Mime
{
    internal static class MagicUtils
    {
        public static string GetDefaultMagicPath()
        {
            string assemblyLocation = typeof(MagicUtils).GetTypeInfo().Assembly.Location;
            string magicDbPath = Path.Combine(assemblyLocation.Replace("Mime.dll", ""), "magic.mgc");

            if (File.Exists(magicDbPath))
            {
                return magicDbPath;
            }

            return null;
        }
    }
}
