using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Raw
{
    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawTransactionResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "locktime")]
        public int LockTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "vin")]
        public Vin[] Vin { get; set; } = new Vin[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "vout")]
        public Vout[] Vout { get; set; } = new Vout[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class Vin
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "vout")]
        public int Vout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "scriptSig")]
        public Scriptsig ScriptSig { get; set; } = new Scriptsig();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "sequence")]
        public long Sequence { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Scriptsig
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "asm")]
        public string Asm { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "hex")]
        public string Hex { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class Vout
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "n")]
        public int N { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "scriptPubKey")]
        public Scriptpubkey ScriptPubKey { get; set; } = new Scriptpubkey();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "assets")]
        public Asset[] Assets { get; set; } = new Asset[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class Scriptpubkey
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "asm")]
        public string Asm { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "hex")]
        public string Hex { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "reqSigs")]
        public int ReqSigs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "addresses")]
        public string[] Addresses { get; set; } = new string[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "issuetxid")]
        public string IssueTxid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "assetref")]
        public string AssetRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "qty")]
        public int Qty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "raw")]
        public int Raw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; } = string.Empty;
    }
}