using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class ListUnspentResult
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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scriptPubKey")]
        public string ScriptPubKey { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cansend")]
        public bool CanSend { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("spendable")]
        public bool Spendable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public ListUnspentAsset[] Assets { get; set; } = new ListUnspentAsset[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("permissions")]
        public object[] Permissions { get; set; } = new object[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListUnspentAsset
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assetref")]
        public string AssetRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("qty")]
        public int? Qty { get; set; }
    }
}