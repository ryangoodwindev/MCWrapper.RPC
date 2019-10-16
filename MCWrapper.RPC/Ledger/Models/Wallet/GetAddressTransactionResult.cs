using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAddressTransactionResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public GetAddressTransactionBalance Balance { get; set; } = new GetAddressTransactionBalance();

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
        public object[] Permissions { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public GetAddressTransactionItem[] Items { get; set; } = new GetAddressTransactionItem[] { };

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
        public GetAddressTransactionVin[] Vin { get; set; } = new GetAddressTransactionVin[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vout")]
        public GetAddressTransactionVout[] Vout { get; set; } = new GetAddressTransactionVout[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetAddressTransactionBalance
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
    public class GetAddressTransactionItem
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
    public class GetAddressTransactionData
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
    public class GetAddressTransactionVin
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
    public class GetAddressTransactionVout
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
        public GetAddressTransactionItem1[] Items { get; set; } = new GetAddressTransactionItem1[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetAddressTransactionItem1
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
    public class GetAddressTransactionData1
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
}