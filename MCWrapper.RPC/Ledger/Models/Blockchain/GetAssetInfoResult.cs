using System.ComponentModel;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAssetInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("issuetxid")]
        public string IssueTxid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("assetref")]
        public object AssetRef { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("multiple")]
        public int Multiple { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("units")]
        public double Units { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("open")]
        public bool Open { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("restrict")]
        public GetAssetInfoRestrict Restrict { get; set; } = new GetAssetInfoRestrict();

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("details")]
        public GetAssetInfoDetails Details { get; set; } = new GetAssetInfoDetails();

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("issueqty")]
        public int IssueQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("issueraw")]
        public int IssueRaw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("issues")]
        public GetAssetInfoIssue[] Issues { get; set; } = new GetAssetInfoIssue[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetAssetInfoRestrict
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("send")]
        public bool Send { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("receive")]
        public bool Receive { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetAssetInfoDetails { }

    /// <summary>
    /// 
    /// </summary>
    public class GetAssetInfoIssue
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("qty")]
        public int Qty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("raw")]
        public int Raw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("details")]
        public GetAssetInfoDetails1 Details { get; set; } = new GetAssetInfoDetails1();

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("issuers")]
        public string[] Issuers { get; set; } = new string[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetAssetInfoDetails1 { }
}