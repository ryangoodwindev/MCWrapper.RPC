using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Raw
{
    /// <summary>
    /// 
    /// </summary>
    public class SignRawTransactionResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("complete")]
        public bool Complete { get; set; }
    }
}