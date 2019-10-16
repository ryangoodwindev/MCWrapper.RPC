using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class ListStreamKeysResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public int Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }
    }
}