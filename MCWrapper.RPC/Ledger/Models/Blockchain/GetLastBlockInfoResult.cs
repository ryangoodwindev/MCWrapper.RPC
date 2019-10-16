using System.ComponentModel;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetLastBlockInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("txcount")]
        public int TxCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("miner")]
        public string Miner { get; set; } = string.Empty;
    }

}