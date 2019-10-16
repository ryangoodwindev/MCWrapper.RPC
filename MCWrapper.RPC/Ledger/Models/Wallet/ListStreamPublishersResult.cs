using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class ListStreamPublishersResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("publisher")]
        public string Publisher { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public int Items { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("first")]
        public ListStreamPublishersFirst First { get; set; } = new ListStreamPublishersFirst();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last")]
        public ListStreamPublishersLast Last { get; set; } = new ListStreamPublishersLast();
    }
    /// <summary>
    /// 
    /// </summary>
    public class ListStreamPublishersFirst
    {
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
        public object Data { get; set; } = new object();

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
        [JsonProperty("vout")]
        public int Vout { get; set; }

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
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListStreamPublishersLast
    {
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
        public object Data { get; set; } = new object();

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
        [JsonProperty("vout")]
        public int Vout { get; set; }

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
    }
}