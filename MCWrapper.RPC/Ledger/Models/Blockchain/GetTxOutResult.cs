using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetTxOutResult
    {
        /// <summary>
        /// 
        /// </summary>
        public GetTxOutResult() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bestblock")]
        public string BestBlock { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("value")]
        public double Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scriptpubkey")]
        public GetTxOutScriptpubkey ScriptPubKey { get; set; } = new GetTxOutScriptpubkey();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("coinbase")]
        public bool Coinbase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public GetTxOutAsset[] Assets { get; set; } = new GetTxOutAsset[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetTxOutScriptpubkey
    {
        /// <summary>
        /// 
        /// </summary>
        public GetTxOutScriptpubkey() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("asm")]
        public string Asm { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reqSigs")]
        public int ReqSigs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetTxOutAsset
    {
        /// <summary>
        /// 
        /// </summary>
        public GetTxOutAsset() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issuetxid")]
        public string IssueTxid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assetref")]
        public object AssetRef { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("qty")]
        public int Qty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("raw")]
        public int Raw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issue")]
        public bool Issue { get; set; }
    }
}