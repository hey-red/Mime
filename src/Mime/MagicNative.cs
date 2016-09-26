using System;
using System.Runtime.InteropServices;

namespace HeyRed.Mime
{
    internal static class MagicNative
    {
        [DllImport("libmagic", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr magic_open(MagicOpenFlags flags);

        [DllImport("libmagic", CallingConvention = CallingConvention.Cdecl)]
        public static extern int magic_load(IntPtr magic_cookie, string filename);

        [DllImport("libmagic", CallingConvention = CallingConvention.Cdecl)]
        public static extern void magic_close(IntPtr magic_cookie);

        [DllImport("libmagic", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr magic_file(IntPtr magic_cookie, string filename);

        [DllImport("libmagic", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr magic_buffer(IntPtr magic_cookie, byte[] buffer, int length);

        [DllImport("libmagic", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr magic_error(IntPtr magic_cookie);
    }
}
