namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Defines all available blockchain raw service method names
    /// </summary>
    public struct RawAction
    {
        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "appendrawchange"
        /// </summary>
        public const string AppendRawChangeMethod = "appendrawchange";

        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "appendrawdata"
        /// </summary>
        public const string AppendRawDataMethod = "appendrawdata";

        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "appendrawtransaction"
        /// </summary>
        public const string AppendRawTransactionMethod = "appendrawtransaction";

        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "createrawtransaction"
        /// </summary>
        public const string CreateRawTransactionMethod = "createrawtransaction";

        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "decoderawtransaction"
        /// </summary>
        public const string DecodeRawTransactionMethod = "decoderawtransaction";

        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "decodescript"
        /// </summary>
        public const string DecodeScriptMethod = "decodescript";

        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "getrawtransaction"
        /// </summary>
        public const string GetRawTransactionMethod = "getrawtransaction";

        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "sendrawtransaction"
        /// </summary>
        public const string SendRawTransactionMethod = "sendrawtransaction";

        /// <summary>
        /// Defines MultiChain Core raw service method as plain string "signrawtransaction"
        /// </summary>
        public const string SignRawTransactionMethod = "signrawtransaction";
    }
}
