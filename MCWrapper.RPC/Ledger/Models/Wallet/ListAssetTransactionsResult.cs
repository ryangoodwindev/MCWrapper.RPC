using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class ListAssetTransactionsResult
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
        public ListAssetTransactionsItem[] Items { get; set; } = new ListAssetTransactionsItem[] { };

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
        [JsonProperty("blockhash")]
        public string BlockHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockindex")]
        public int BlockIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blocktime")]
        public int BlockTime { get; set; }

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
        public ListAssetTransactionsVin[] Vin { get; set; } = new ListAssetTransactionsVin[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vout")]
        public ListAssetTransactionsVout[] Vout { get; set; } = new ListAssetTransactionsVout[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetTransactionsItem
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("streamref")]
        public string StreamRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("publishers")]
        public string[] Publishers { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("keys")]
        public string[] Keys { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("offchain")]
        public bool OffChain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("available")]
        public bool Available { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetTransactionsVin
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
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public ListAssetTransactionsAsset[] Assets { get; set; } = new ListAssetTransactionsAsset[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetTransactionsAsset
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
        public int Qty { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetTransactionsVout
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
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public ListAssetTransactionsAsset1[] Assets { get; set; } = new ListAssetTransactionsAsset1[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("permissions")]
        public ListAssetTransactionsPermission[] Permissions { get; set; } = new ListAssetTransactionsPermission[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public ListAssetTransactionsItem1[] Items { get; set; } = new ListAssetTransactionsItem1[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetTransactionsAsset1
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
        public int Qty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetTransactionsPermission
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("_for")]
        public object For { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connect")]
        public bool Connect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("send")]
        public bool Send { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("receive")]
        public bool Receive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("create")]
        public bool Create { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issue")]
        public bool Issue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mine")]
        public bool Mine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("admin")]
        public bool Admin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("activate")]
        public bool Activate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("startblock")]
        public int StartBlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("endblock")]
        public long EndBlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timestamp")]
        public int TimeStamp { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetTransactionsItem1
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("streamref")]
        public string StreamRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("publishers")]
        public string[] Publishers { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("keys")]
        public string[] Keys { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("offchain")]
        public bool OffChain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("available")]
        public bool Available { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; } = string.Empty;
    }
}