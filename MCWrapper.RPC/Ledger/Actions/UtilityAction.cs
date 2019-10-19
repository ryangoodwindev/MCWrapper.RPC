namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Defines all available blockchain utility service method names
    /// </summary>
    public struct UtilityAction
    {
        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "appendbinarycache"
        /// </summary>
        public const string AppendBinaryCacheMethod = "appendbinarycache";

        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "createbinarycache"
        /// </summary>
        public const string CreateBinaryCacheMethod = "createbinarycache";

        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "createkeypairs"
        /// </summary>
        public const string CreateKeyPairsMethod = "createkeypairs";

        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "createmultisig"
        /// </summary>
        public const string CreateMultiSigMethod = "createmultisig";

        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "deletebinarycache"
        /// </summary>
        public const string DeleteBinaryCacheMethod = "deletebinarycache";

        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "estimatefee"
        /// </summary>
        public const string EstimateFeeMethod = "estimatefee";

        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "estimatepriority"
        /// </summary>
        public const string EstimatePriorityMethod = "estimatepriority";

        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "validateaddress"
        /// </summary>
        public const string ValidateAddressMethod = "validateaddress";

        /// <summary>
        /// Defines MultiChain Core utility service method as plain string "verifymessage"
        /// </summary>
        public const string VerifyMessageMethod = "verifymessage";
    }
}