using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class ListTxFiltersResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("createtxid")]
        public string CreateTxid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("filterref")]
        public object FilterRef { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("codelength")]
        public int CodeLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("for")]
        public object[] For { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("creators")]
        public string[] Creators { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("compiled")]
        public bool Compiled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("approved")]
        public bool Approved { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("admins")]
        public object[] Admins { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pending")]
        public object[] Pending { get; set; } = new object[] { };
    }
}