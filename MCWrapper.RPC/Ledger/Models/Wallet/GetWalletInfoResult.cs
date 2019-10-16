using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWalletInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("walletversion")]
        public int WalletVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public float Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("walletdbversion")]
        public int WalletDbVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txcount")]
        public int TxCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("utxocount")]
        public int UtxoCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("keypoololdest")]
        public int KeyPoolOldest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("keypoolsize")]
        public int KeyPoolSize { get; set; }
    }
}