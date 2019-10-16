using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class PrepareLockUnspentResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vout")]
        public int Vout { get; set; }
    }
}