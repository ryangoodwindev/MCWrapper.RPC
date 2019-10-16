using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class ListPermissionsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ListPermissionsResult() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("_for")]
        public object For { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("startblock")]
        public int StartBlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("endblock")]
        public long EndBlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("admins")]
        public string[] Admins { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pending")]
        public object[] Pending { get; set; } = new object[] { };
    }
}
