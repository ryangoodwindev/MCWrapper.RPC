using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAddressBalancesResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assetref")]
        public string AssetRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("qty")]
        public float Qty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("raw")]
        public float Raw { get; set; }
    }
}