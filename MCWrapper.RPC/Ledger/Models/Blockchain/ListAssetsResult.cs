using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class ListAssetsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ListAssetsResult() { }

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
        public ListAssetsRestrict Restrict { get; set; } = new ListAssetsRestrict();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("details")]
        public ListAssetsDetails Details { get; set; } = new ListAssetsDetails();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issueqty")]
        public int IssueqQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issueraw")]
        public int IssueRaw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issues")]
        public ListAssetsIssue[] Issues { get; set; } = new ListAssetsIssue[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetsRestrict
    {
        /// <summary>
        /// 
        /// </summary>
        public ListAssetsRestrict() { }

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
    public class ListAssetsDetails { }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetsIssue
    {
        /// <summary>
        /// 
        /// </summary>
        public ListAssetsIssue() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;

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
        [JsonProperty("details")]
        public ListAssetsDetails1 Details { get; set; } = new ListAssetsDetails1();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issuers")]
        public string[] Issuers { get; set; } = new string[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListAssetsDetails1 { }
}
