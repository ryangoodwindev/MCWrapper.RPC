using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Control
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRuntimeParamsResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reindex")]
        public bool ReIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("rescan")]
        public bool ReScan { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txindex")]
        public bool TxIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("autocombineminconf")]
        public int AutoCombineMinConf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("autocombinemininputs")]
        public int AutoCombineMinInputs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("autocombinemaxinputs")]
        public int AutoCombineMaxInputs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("autocombinedelay")]
        public int AutoCombineDelay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("autocombinesuspend")]
        public int AutoCombineSuspend { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("autosubscribe")]
        public string AutoSubscribe { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("handshakelocal")]
        public string HandShakeLocal { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bantx")]
        public string BanTx { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lockblock")]
        public string LockBlock { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hideknownopdrops")]
        public bool HideKnownOpDrops { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maxshowndata")]
        public int MaxShownData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maxqueryscanitems")]
        public int MaxQueryScanItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("v1apicompatible")]
        public bool V1ApiCompatible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miningrequirespeers")]
        public bool MiningRequiresPeers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mineemptyrounds")]
        public int MineEmptyRounds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miningturnover")]
        public float MiningTurnover { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lockadminminerounds")]
        public int LockAdminMineRounds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("gen")]
        public bool Gen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("genproclimit")]
        public int GenProcLimit { get; set; }
    }
}
