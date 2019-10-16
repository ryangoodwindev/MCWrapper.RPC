namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Defines all available blockchain control service method names
    /// </summary>
    public struct ControlAction
    {
        /// <summary>
        /// Defines MultiChain Core control service method as plain string "clearmempool"
        /// </summary>
        public const string ClearMemPoolMethod = "clearmempool";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "getblockchainparams"
        /// </summary>
        public const string GetBlockchainParamsMethod = "getblockchainparams";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "getinfo"
        /// </summary>
        public const string GetInfoMethod = "getinfo";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "getruntimeparams"
        /// </summary>
        public const string GetRuntimeParamsMethod = "getruntimeparams";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "help"
        /// </summary>
        public const string HelpMethod = "help";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "pause"
        /// </summary>
        public const string PauseMethod = "pause";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "resume"
        /// </summary>
        public const string ResumeMethod = "resume";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "setlastblock"
        /// </summary>
        public const string SetLastBlockMethod = "setlastblock";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "setruntimeparam"
        /// </summary>
        public const string SetRuntimeParamMethod = "setruntimeparam";

        /// <summary>
        /// Defines MultiChain Core control service method as plain string "stop"
        /// </summary>
        public const string StopMethod = "stop";
    }
}
