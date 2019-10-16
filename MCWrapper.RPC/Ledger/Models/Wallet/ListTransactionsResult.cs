using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class ListTransactionsResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public Balance Balance { get; set; } = new Balance();

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
        public ListTransactionsPermission[] Permissions { get; set; } = new ListTransactionsPermission[] { };

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
        [JsonProperty("issue")]
        public Issue Issue { get; set; } = new Issue();
    }

    /// <summary>
    /// 
    /// </summary>
    public class Balance
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public Asset[] Assets { get; set; } = new Asset[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class Asset
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
    public class Issue
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
        [JsonProperty("multiple")]
        public int Multiple { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("units")]
        public int Units { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("open")]
        public bool Open { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("restrict")]
        public ListTransactionsRestrict Restrict { get; set; } = new ListTransactionsRestrict();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("details")]
        public Details Details { get; set; } = new Details();

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
    public class ListTransactionsRestrict
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Send")]
        public bool Send { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Receive")]
        public bool Receive { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Details
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("units")]
        public int Units { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("open")]
        public bool Open { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public object[] Items { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expectation")]
        public Expectation Expectation { get; set; } = new Expectation();
    }

    /// <summary>
    /// 
    /// </summary>
    public class Expectation { }

    /// <summary>
    /// 
    /// </summary>
    public class ListTransactionsPermission
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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };
    }
}