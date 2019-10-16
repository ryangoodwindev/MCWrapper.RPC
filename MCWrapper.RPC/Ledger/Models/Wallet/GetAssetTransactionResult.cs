using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAssetTransactionResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public object Addresses { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public object[] Items { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public object[] Data { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timereceived")]
        public int TimeReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vin")]
        public GetAssetTransactionVin[] Vin { get; set; } = new GetAssetTransactionVin[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vout")]
        public GetAssetTransactionVout[] Vout { get; set; } = new GetAssetTransactionVout[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetAssetTransactionVin
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
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

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
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetAssetTransactionVout
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("n")]
        public int N { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

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
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public object[] Assets { get; set; } = new object[] { };
    }
}