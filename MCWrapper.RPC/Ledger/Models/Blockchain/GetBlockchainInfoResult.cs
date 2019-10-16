using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetBlockchainInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        public GetBlockchainInfoResult() { }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chain")]
        public string Chain { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainname")]
        public string ChainName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("setupblocks")]
        public int SetupBlocks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reindex")]
        public bool ReIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blocks")]
        public int Blocks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("headers")]
        public int Headers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bestblockhash")]
        public string BestBlockHash { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("difficulty")]
        public float Difficulty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("verificationprogress")]
        public int VerificationProgress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainwork")]
        public string Chainwork { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainrewards")]
        public int ChainRewards { get; set; }
    }
}
