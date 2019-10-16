using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class ListStreamsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ListStreamsResult() { }

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
        [JsonProperty("streamref")]
        public string StreamRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("open")]
        public bool Open { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("details")]
        public StreamDetails Details { get; set; } = new StreamDetails();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("creators")]
        public string[] Creators { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class StreamDetails
    {
        /// <summary>
        /// 
        /// </summary>
        public StreamDetails() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("createdon")]
        public string CreatedOn { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("createdat")]
        public string CreatedAt { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("permissiongranted")]
        public string PermissionsGranted { get; set; } = string.Empty;
    }
}
