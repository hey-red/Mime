using System.IO;
using System.Reflection;

namespace HeyRed.Mime
{
    public static class MagicUtils
    {
        public static string GetDefaultMagicPath()
        {
            string assemblyLocation = typeof(MagicUtils).GetTypeInfo().Assembly.Location;
            string magicDbPath = Path.Combine(assemblyLocation, "magic.mgc");

            if (File.Exists(magicDbPath))
            {
                return magicDbPath;
            }

            return null;
        }
    }
}
