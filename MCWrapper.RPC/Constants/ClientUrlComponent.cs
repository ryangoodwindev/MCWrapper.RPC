namespace MCWrapper.RPC.Constants
{
    /// <summary>
    /// Helper object that stores some constant values we can use while configuring the base RpcClient
    /// </summary>
    public struct ClientUrlComponent
    {
        /// <summary>
        /// Represents non-secured HTTP prefix
        /// </summary>
        public const string Http = "http";

        /// <summary>
        /// Represent secured HTTPS prefix
        /// </summary>
        public const string Https = "https";

        /// <summary>
        /// Enforces proper URI format
        /// </summary>
        public const string Format = "{0}://{1}:{2}/";

        /// <summary>
        /// Authentication header type value
        /// </summary>
        public const string BasicHeaderValue = "Basic";

        /// <summary>
        /// Default MultiChain client
        /// </summary>
        public const string MultiChainClient = "MultiChainClient";

        /// <summary>
        /// StringContent MediaFormatHeader value
        /// </summary>
        public const string JsonRPCMediaType = "application/json-rpc";
    }
}