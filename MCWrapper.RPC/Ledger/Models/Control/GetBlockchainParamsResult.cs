using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Control
{
    /// <summary>
    /// 
    /// </summary>
    public class GetBlockchainParamsResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainprotocol")]
        public string ChainProtocol { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chaindescription")]
        public string ChainDescription { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("rootstreamname")]
        public string RootStreamName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("rootstreamopen")]
        public bool RootStreamOpen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainistestnet")]
        public bool ChainIsTestNet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("targetblocktime")]
        public int TargetBlockTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maximumblocksize")]
        public int MaximumBlockSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maximumchunksize")]
        public int MaximumChunkSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maximumchunkcount")]
        public int MaximumChunkCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultnetworkport")]
        public int DefaultNetworkPort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultrpcport")]
        public int DefaultRpcPort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecanconnect")]
        public bool AnyoneCanConnect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecansend")]
        public bool AnyoneCanSend { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecanreceive")]
        public bool AnyoneCanReceive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecanreceiveempty")]
        public bool AnyoneCanReceiveEmpty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecancreate")]
        public bool AnyoneCanCreate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecanissue")]
        public bool AnyoneCanIssue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecanmine")]
        public bool AnyoneCanMine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecanactivate")]
        public bool AnyoneCanActivate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("anyonecanadmin")]
        public bool AnyoneCanAdmin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("supportminerprecheck")]
        public bool SupportMinerPreCheck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("allowarbitraryoutputs")]
        public bool AllowArbitraryOutputs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("allowp2shoutputs")]
        public bool AllowP2shOutputs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("allowmultisigoutputs")]
        public bool AllowMultiSigOutputs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("setupfirstblocks")]
        public int SetupFirstBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miningdiversity")]
        public float MiningDiversity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("adminconsensusupgrade")]
        public float AdminConsensusUpgrade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("adminconsensusadmin")]
        public float AdminConsensusAdmin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("adminconsensusactivate")]
        public float AdminConsensusActivate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("adminconsensusmine")]
        public float AdminConsensusMine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("adminconsensuscreate")]
        public float AdminConsensusCreate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("adminconsensusissue")]
        public float AdminConsensusIssue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lockadminminerounds")]
        public int LockAdminMineRounds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miningrequirespeers")]
        public bool MiningRequiresPeers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mineemptyrounds")]
        public float MineEmptyRounds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miningturnover")]
        public float MiningTurnover { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("firstblockreward")]
        public int FirstBlockReward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("initialblockreward")]
        public int InitialBlockReward { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("rewardhalvinginterval")]
        public int RewardHalvingInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("rewardspendabledelay")]
        public int RewardSpendableDelay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minimumperoutput")]
        public int MinimumPerOutput { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maximumperoutput")]
        public long MaximumPerOutput { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minimumoffchainfee")]
        public int MinimumOffChainFee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minimumrelayfee")]
        public int MinimumRelayFee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nativecurrencymultiple")]
        public int NativeCurrencyMultiple { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("skippowcheck")]
        public bool SkipPowCheck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("powminimumbits")]
        public int PowMinimumBits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("targetadjustfreq")]
        public int TargetAdjustFreq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("allowmindifficultyblocks")]
        public bool AllowMinDifficultyBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("onlyacceptstdtxs")]
        public bool OnlyAcceptstDtxs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maxstdtxsize")]
        public int MaxStdTxSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maxstdopreturnscount")]
        public int MaxStdOpReturnsCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maxstdopreturnsize")]
        public int MaxStdOpReturnSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maxstdopdropscount")]
        public int MaxStdOpDropsCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maxstdelementsize")]
        public int MaxStdElementSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainname")]
        public string ChainName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("protocolversion")]
        public int ProtocolVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("networkmessagestart")]
        public string NetworkMessageStart { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresspubkeyhashversion")]
        public string AddressPubkeyHashVersion { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addressscripthashversion")]
        public string AddressScriptHashVersion { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("privatekeyversion")]
        public string PrivateKeyVersion { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresschecksumvalue")]
        public string AddressCheckSumValue { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("genesispubkey")]
        public string GenesisPubKey { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("genesisversion")]
        public int GenesisVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("genesistimestamp")]
        public int GenesisTimeStamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("genesisnbits")]
        public int GenesisNBits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("genesisnonce")]
        public int GenesisNonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("genesispubkeyhash")]
        public string GenesisPubKeyHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("genesishash")]
        public string GenesisHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainparamshash")]
        public string ChainParamsHash { get; set; } = string.Empty;
    }
}
