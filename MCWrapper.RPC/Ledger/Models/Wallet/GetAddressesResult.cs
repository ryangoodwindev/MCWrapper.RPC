using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAddressesResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ismine")]
        public bool IsMine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("iswatchonly")]
        public bool IsWatchOnly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isscript")]
        public bool IsScript { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pubkey")]
        public string PubKey { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("iscompressed")]
        public bool IsCompressed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("synchronized")]
        public bool Synchronized { get; set; }
    }
}