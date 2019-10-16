using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMultiSigResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("redeemScript")]
        public string RedeemScript { get; set; } = string.Empty;
    }
}