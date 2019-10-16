using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateKeyPairsResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pubkey")]
        public string PubKey { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("privkey")]
        public string PrivKey { get; set; } = string.Empty;
    }
}