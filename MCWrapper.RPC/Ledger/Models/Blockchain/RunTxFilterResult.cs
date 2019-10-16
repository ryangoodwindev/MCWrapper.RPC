using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    /// <summary>
    /// Result:
    /// {
    ///   "compiled": true|false,           (boolean) Filter passed compilation
    ///   "passed": true|false,             (boolean) Transaction passed the filter
    ///   "callbacks": callbacks,           (array of objects) Information about callback calls by filter
    ///   "reason": "rejection reason",     (boolean) Reason for rejection, null if passed
    ///   "time": x.xxxxxx,                 (numeric) Seconds to run transaction through the filter
    /// }
    /// </summary>
    public class RunTxFilterResult
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
