using System;
using System.Runtime.InteropServices;

namespace HeyRed.MimeGuesser
{
    internal static class MagicNative
    {
        [DllImport("libmagic1", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr magic_open(MagicOpenFlags flags);

        [DllImport("libmagic1", CallingConvention = CallingConvention.Cdecl)]
        public static extern int magic_load(IntPtr magic_cookie, string filename);

        [DllImport("libmagic1", CallingConvention = CallingConvention.Cdecl)]
        public static extern void magic_close(IntPtr magic_cookie);

        [DllImport("libmagic1", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr magic_file(IntPtr magic_cookie, string filename);

        [DllImport("libmagic1", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr magic_buffer(IntPtr magic_cookie, byte[] buffer, int length);

        [DllImport("libmagic1", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr magic_error(IntPtr magic_cookie);
    }
}
