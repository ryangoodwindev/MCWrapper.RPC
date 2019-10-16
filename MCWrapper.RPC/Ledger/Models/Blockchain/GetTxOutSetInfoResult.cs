using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetTxOutSetInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        public GetTxOutSetInfoResult() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bestblock")]
        public string BestBlock { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transactions")]
        public int Transactions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txouts")]
        public int TxOuts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bytes_serialized")]
        public int Bytes_Serialized { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash_serialized")]
        public string Hash_Serialized { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_amount")]
        public int Total_Amount { get; set; }
    }
}
