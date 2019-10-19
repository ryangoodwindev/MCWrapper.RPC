namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Defines all available blockchain mining service method names
    /// </summary>
    public struct MiningAction
    {
        /// <summary>
        /// Defines MultiChain Core mine service method as plain string "getblocktemplate"
        /// </summary>
        public const string GetBlockTemplateMethod = "getblocktemplate";

        /// <summary>
        /// Defines MultiChain Core mine service method as plain string "getmininginfo"
        /// </summary>
        public const string GetMiningInfoMethod = "getmininginfo";

        /// <summary>
        /// Defines MultiChain Core mine service method as plain string "getnetworkhashps"
        /// </summary>
        public const string GetNetworkHashPsMethod = "getnetworkhashps";

        /// <summary>
        /// Defines MultiChain Core mine service method as plain string "prioritisetransaction"
        /// </summary>
        public const string PrioritiseTransactionMethod = "prioritisetransaction";

        /// <summary>
        /// Defines MultiChain Core mine service method as plain string "submitblock"
        /// </summary>
        public const string SubmitBlockMethod = "submitblock";
    }
}