using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class ListBlocksResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ListBlocksResult() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miner")]
        public string Miner { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txcount")]
        public int TxCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("merkleroot")]
        public string MerkleRoot { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bits")]
        public string Bits { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("difficulty")]
        public float Difficulty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addchainworkress")]
        public string ChainWork { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("previousblockhash")]
        public string PreviousBlockHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nextblockhash")]
        public string NextBlockHash { get; set; } = string.Empty;
    }
}
