using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class GetMemPoolInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        public GetMemPoolInfoResult() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="bytes"></param>
        public GetMemPoolInfoResult(int size, int bytes)
        {
            Size = size;
            Bytes = bytes;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bytes")]
        public int Bytes { get; set; }
    }
}