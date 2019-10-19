namespace MCWrapper.RPC.Constants
{
    /// <summary>
    /// Entity types are used in Create methods on the blockchain network;
    /// e.g. Create and CreateFrom;
    /// </summary>
    public struct Entity
    {
        /// <summary>
        /// Asset entity type
        /// </summary>
        public const string Asset = "asset";

        /// <summary>
        /// Stream entity type
        /// </summary>
        public const string Stream = "stream";

        /// <summary>
        /// StreamItem entity type
        /// </summary>
        public const string StreamItem = "streamitem";

        /// <summary>
        /// Upgrade entity type
        /// </summary>
        public const string Upgrade = "upgrade";

        /// <summary>
        /// Transaction filter entity type
        /// </summary>
        public const string TxFilter = "txfilter";

        /// <summary>
        /// Stream filter entity type
        /// </summary>
        public const string StreamFilter = "streamfilter";
    }
}