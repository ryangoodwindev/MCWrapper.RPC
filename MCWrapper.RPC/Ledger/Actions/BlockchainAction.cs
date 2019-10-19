namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Defines all available blockchain service method names
    /// </summary>
    public struct BlockchainAction
    {
        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getassetinfo"
        /// </summary>
        public const string GetAssetInfoMethod = "getassetinfo";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getbestblockhash"
        /// </summary>
        public const string GetBestBlockHashMethod = "getbestblockhash";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getblock"
        /// </summary>
        public const string GetBlockMethod = "getblock";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getblockchaininfo"
        /// </summary>
        public const string GetBlockChainInfoMethod = "getblockchaininfo";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getblockcount"
        /// </summary>
        public const string GetBlockCountMethod = "getblockcount";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getblockhash"
        /// </summary>
        public const string GetBlockHashMethod = "getblockhash";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getchaintips"
        /// </summary>
        public const string GetChainTipsMethod = "getchaintips";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getdifficulty"
        /// </summary>
        public const string GetDifficultyMethod = "getdifficulty";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getfiltercode"
        /// </summary>
        public const string GetFilterCodeMethod = "getfiltercode";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getlastblockinfo"
        /// </summary>
        public const string GetLastBlockInfoMethod = "getlastblockinfo";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getmempoolinfo"
        /// </summary>
        public const string GetMemPoolInfoMethod = "getmempoolinfo";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getrawmempool"
        /// </summary>
        public const string GetRawMemPoolMethod = "getrawmempool";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "getstreaminfo"
        /// </summary>
        public const string GetStreamInfoMethod = "getstreaminfo";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "gettxout"
        /// </summary>
        public const string GetTxOutMethod = "gettxout";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "gettxoutsetinfo"
        /// </summary>
        public const string GetTxOutSetInfoMethod = "gettxoutsetinfo";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "listassets"
        /// </summary>
        public const string ListAssetsMethod = "listassets";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "listblocks"
        /// </summary>
        public const string ListBlocksMethod = "listblocks";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "listpermissions"
        /// </summary>
        public const string ListPermissionsMethod = "listpermissions";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "liststreamfilters"
        /// </summary>
        public const string ListStreamFiltersMethod = "liststreamfilters";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "liststreams"
        /// </summary>
        public const string ListStreamsMethod = "liststreams";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "listtxfilters"
        /// </summary>
        public const string ListTxFiltersMethod = "listtxfilters";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "listupgrades"
        /// </summary>
        public const string ListUpgradesMethod = "listupgrades";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "runstreamfilter"
        /// </summary>
        public const string RunStreamFilterMethod = "runstreamfilter";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "runtxfilter"
        /// </summary>
        public const string RunTxFilterMethod = "runtxfilter";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "teststreamfilter"
        /// </summary>
        public const string TestStreamFilterMethod = "teststreamfilter";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "testtxfilter"
        /// </summary>
        public const string TestTxFilterMethod = "testtxfilter";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "verifychain"
        /// </summary>
        public const string VerifyChainMethod = "verifychain";

        /// <summary>
        /// Defines MultiChain Core blockchain service method as plain string "verifypermission"
        /// </summary>
        public const string VerifyPermissionMethod = "verifypermission";
    }
}