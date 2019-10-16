using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetChainTipsResult
    {
        /// <summary>
        /// 
        /// </summary>
        public GetChainTipsResult() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branchlen")]
        public int BranchLen { get; set; }

        /// <summary>
        /// Possible values for status:
        /// 1.  "invalid"                       This branch contains at least one invalid block
        /// 2.  "headers-only"                  Not all blocks for this branch are available, but the headers are valid
        /// 3.  "valid-headers"                 All blocks are available for this branch, but they were never fully validated
        /// 4.  "valid-fork"                    This branch is not part of the active chain, but is fully validated
        /// 5.  "active"  
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;
    }
}
