using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// 
    /// </summary>
    public class RunStreamFilterResult
    {
        /// <summary>
        /// Filter passed compilation
        /// </summary>
        [JsonProperty("compiled")]
        public bool Compiled { get; set; }

        /// <summary>
        /// Transaction passed the filter
        /// </summary>
        [JsonProperty("passed")]
        public bool Passed { get; set; }

        /// <summary>
        ///  Information about callback calls by filter
        /// </summary>
        [JsonProperty("callbacks")]
        public object[] CallBacks { get; set; } = new object[] { };

        /// <summary>
        /// Reason for rejection, null if passed
        /// </summary>
        [JsonProperty("reason")]
        public bool? Reason { get; set; }

        /// <summary>
        /// Seconds to run transaction through the filter
        /// </summary>
        [JsonProperty("time")]
        public double Time { get; set; }
    }
}
