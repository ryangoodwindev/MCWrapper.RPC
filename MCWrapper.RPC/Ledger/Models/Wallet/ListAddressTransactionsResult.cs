using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public ListAddressTransactionsBalance Balance { get; set; } = new ListAddressTransactionsBalance();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("myaddresses")]
        public string[] MyAddresses { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("permissions")]
        public ListAddressTransactionsPermission[] Permissions { get; set; } = new ListAddressTransactionsPermission[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public ListAddressTransactionsItem[] Items { get; set; } = new ListAddressTransactionsItem[] { };

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
        [JsonProperty("vin")]
        public ListAddressTransactionsVin[] Vin { get; set; } = new ListAddressTransactionsVin[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vout")]
        public ListAddressTransactionsVout[] Vout { get; set; } = new ListAddressTransactionsVout[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsBalance
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public float Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public object[] Assets { get; set; } = new object[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsPermission
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

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsItem
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
        public object Data { get; set; } = new { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsData
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
        [JsonProperty("format")]
        public string Format { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsVin
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
        public float Amount { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsVout
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
        public float Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public ListAddressTransactionsItem1[] Items { get; set; } = new ListAddressTransactionsItem1[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("permissions")]
        public ListAddressTransactionsPermission1[] Permissions { get; set; } = new ListAddressTransactionsPermission1[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsItem1
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
        public object Data { get; set; } = new { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsData1
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
        [JsonProperty("format")]
        public string Format { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAddressTransactionsPermission1
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
        [JsonProperty("Receive")]
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
}