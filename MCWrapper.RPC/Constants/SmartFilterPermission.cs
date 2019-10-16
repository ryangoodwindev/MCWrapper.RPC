namespace MCWrapper.RPC.Constants
{
    /// <summary>
    /// MultiChain 2.0 also supports six custom permissions that are useful for defining roles that are enforced by smart filters
    /// <para>
    ///     high1, high2, high3 – custom permissions that can be set by users with admin privileges.
    /// </para>
    /// <para>
    ///     low1, low2, low3 – custom permissions that can be set by users with admin or activate privileges.
    /// </para>
    /// </summary>
    public struct SmartFilterPermission
    {
        /// <summary>
        /// Low - High permissions
        /// </summary>
        public const string HighOne = "high1";

        /// <summary>
        /// Mid - High permissions
        /// </summary>
        public const string HighTwo = "high2";

        /// <summary>
        /// High - High permissions
        /// </summary>
        public const string HighThree = "high3";

        /// <summary>
        /// Low - Low permissions
        /// </summary>
        public const string LowOne = "low1";

        /// <summary>
        /// Mid - Low permissions
        /// </summary>
        public const string LowTwo = "low2";

        /// <summary>
        /// High - Low permissions
        /// </summary>
        public const string LowThree = "low3";
    }
}
