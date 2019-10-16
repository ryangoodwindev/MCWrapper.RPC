using System.ComponentModel;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetStreamInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("createtxid")]
        public string CreateTxid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("streamref")]
        public string StreamRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("restrict")]
        public GetStreamInfoRestrict Restrict { get; set; } = new GetStreamInfoRestrict();

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("details")]
        public GetStreamInfoDetails Details { get; set; } = new GetStreamInfoDetails();

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("creators")]
        public string[] Creators { get; set; } = new string[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetStreamInfoRestrict
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("write")]
        public bool Write { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("onchain")]
        public bool OnChain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("offchain")]
        public bool OffChain { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetStreamInfoDetails { }
}