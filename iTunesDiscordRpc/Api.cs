using System.Runtime.InteropServices;

namespace iTunesDiscordRpc
{
    public static class Api
    {
        [DllImport("itunes.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Initialize([MarshalAs(UnmanagedType.Bool)] bool needsCoInit = false);

        [DllImport("itunes.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnInitialize([MarshalAs(UnmanagedType.Bool)] bool needsCoUnInit = false);

        [DllImport("itunes.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentTrackLength([MarshalAs(UnmanagedType.I8)] ref long seconds);

        [DllImport("itunes.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentPosition([MarshalAs(UnmanagedType.I8)] ref long seconds);

        [DllImport("itunes.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentTrackName([MarshalAs(UnmanagedType.BStr)] ref string name);

        [DllImport("itunes.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentTrackAuthor([MarshalAs(UnmanagedType.BStr)] ref string name);

        [DllImport("itunes.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentTrackAlbum([MarshalAs(UnmanagedType.BStr)] ref string name);
    }
}
