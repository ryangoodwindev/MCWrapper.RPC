using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public ListWalletTransactionsBalance Balance { get; set; } = new ListWalletTransactionsBalance();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("myaddresses")]
        public string[] MyAddresses { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public object[] Addresses { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("permissions")]
        public ListWalletTransactionsPermission[] Permissions { get; set; } = new ListWalletTransactionsPermission[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issue")]
        public ListWalletTransactionsIssue Issue { get; set; } = new ListWalletTransactionsIssue();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public object[] Items { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public string[] Data { get; set; } = new string[] { };

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
        [JsonProperty("comment")]
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("create")]
        public ListWalletTransactionsCreate Create { get; set; } = new ListWalletTransactionsCreate();
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsBalance
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public ListWalletTransactionsAsset[] Assets { get; set; } = new ListWalletTransactionsAsset[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsAsset
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
        public object AssetRef { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("qty")]
        public int Qty { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsIssue
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
        public object AssetRef { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("multiple")]
        public int Multiple { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("units")]
        public float Units { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("open")]
        public bool Open { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("restrict")]
        public ListWalletTransactionsRestrict Restrict { get; set; } = new ListWalletTransactionsRestrict();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("details")]
        public ListWalletTransactionsDetails Details { get; set; } = new ListWalletTransactionsDetails();

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
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsRestrict
    {
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
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsDetails { }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsCreate
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
        public object StreamRef { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("restrict")]
        public ListWalletTransactionsRestrict1 Restrict { get; set; } = new ListWalletTransactionsRestrict1();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("details")]
        public ListWalletTransactionsDetails1 Details { get; set; } = new ListWalletTransactionsDetails1();
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsRestrict1
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("write")]
        public bool Write { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("onchain")]
        public bool OnChain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("offchain")]
        public bool OffChain { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsDetails1 { }

    /// <summary>
    /// 
    /// </summary>
    public class ListWalletTransactionsPermission
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("_for")]
        public object For { get; set; } = new object() { };

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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };
    }
}