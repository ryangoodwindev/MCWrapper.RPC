namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Struct hosts OffChain service methods
    /// </summary>
    public struct OffChainAction
    {
        /// <summary>
        /// Defines MultiChain Core offhchain service method as plain string "purgepublisheditems"
        /// </summary>
        public const string PurgePublishedItems = "purgepublisheditems";

        /// <summary>
        /// Defines MultiChain Core offhchain service method as plain string "purgestreamitems"
        /// </summary>
        public const string PurgeStreamItems = "purgestreamitems";

        /// <summary>
        /// Defines MultiChain Core offhchain service method as plain string "retrievestreamitems"
        /// </summary>
        public const string RetrieveStreamItems = "retrievestreamitems";
    }
}
