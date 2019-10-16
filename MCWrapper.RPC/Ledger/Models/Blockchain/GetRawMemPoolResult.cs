using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRawMemPoolResult
    {
        /// <summary>
        /// 
        /// </summary>
        public GetRawMemPoolResult() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transactions")]
        public object Transactions { get; set; } = new { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class TransactionId
    {
        /// <summary>
        /// 
        /// </summary>
        public TransactionId() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fee")]
        public float Fee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("startingpriority")]
        public int StartingPriority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currentpriority")]
        public int CurrentPriority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("depends")]
        public string[] Depends { get; set; } = new string[] { };
    }
}
