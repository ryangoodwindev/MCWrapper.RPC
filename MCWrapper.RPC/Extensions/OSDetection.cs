using System.Runtime.InteropServices;

namespace MCWrapper.RPC.Extensions
{
    /// <summary>
    /// Courtesy of https://mariusschulz.com/blog/detecting-the-operating-system-in-net-core
    /// Great work, thank you.
    /// </summary>
    public static class OSDetection
    {
        /// <summary>
        /// Detect windows (meh)
        /// </summary>
        /// <returns></returns>
        public static bool IsWindows() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        /// <summary>
        /// Detect mac (boooooo)
        /// </summary>
        /// <returns></returns>
        public static bool IsMacOS() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        /// Detect Linux (hooray!)
        /// </summary>
        /// <returns></returns>
        public static bool IsLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}
