namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Defines all available blockchain network service method names
    /// </summary>
    public struct NetworkAction
    {
        /// <summary>
        /// Defines MultiChain Core network service method as plain string "addnode"
        /// </summary>
        public const string AddNodeMethod = "addnode";

        /// <summary>
        /// Defines MultiChain Core network service method as plain string "getaddednodeinfo"
        /// </summary>
        public const string GetAddedNodeInfoMethod = "getaddednodeinfo";

        /// <summary>
        /// Defines MultiChain Core network service method as plain string "getchunkqueueinfo"
        /// </summary>
        public const string GetChunkQueueInfoMethod = "getchunkqueueinfo";

        /// <summary>
        /// Defines MultiChain Core network service method as plain string "getchunkqueuetotals"
        /// </summary>
        public const string GetChunkQueueTotalsMethod = "getchunkqueuetotals";

        /// <summary>
        /// Defines MultiChain Core network service method as plain string "getconnectioncount"
        /// </summary>
        public const string GetConnectionCountMethod = "getconnectioncount";

        /// <summary>
        /// Defines MultiChain Core network service method as plain string "getnettotals"
        /// </summary>
        public const string GetNetTotalsMethod = "getnettotals";

        /// <summary>
        /// Defines MultiChain Core network service method as plain string "getnetworkinfo"
        /// </summary>
        public const string GetNetworkInfoMethod = "getnetworkinfo";

        /// <summary>
        /// Defines MultiChain Core network service method as plain string "getpeerinfo"
        /// </summary>
        public const string GetPeerInfoMethod = "getpeerinfo";

        /// <summary>
        /// Defines MultiChain Core network service method as plain string "ping"
        /// </summary>
        public const string PingMethod = "ping";
    }
}