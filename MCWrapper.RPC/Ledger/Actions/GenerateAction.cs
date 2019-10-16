namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Defines all available blockchain generate service method names
    /// </summary>
    public struct GenerateAction
    {
        /// <summary>
        /// Defines MultiChain Core generate service method as plain string "getgenerate"
        /// </summary>
        public const string GetGenerateMethod = "getgenerate";

        /// <summary>
        /// Defines MultiChain Core generate service method as plain string "gethashespersec"
        /// </summary>
        public const string GetHashesPerSecMethod = "gethashespersec";

        /// <summary>
        /// Defines MultiChain Core generate service method as plain string "setgenerate"
        /// </summary>
        public const string SetGenerateMethod = "setgenerate";
    }
}
