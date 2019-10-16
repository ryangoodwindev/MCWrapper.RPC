using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Network
{
    /// <summary>
    /// Result:
    /// [
    ///   {
    ///     "addednode" : "192.168.0.201",          (string) The node ip address
    ///     "connected" : true|false,               (boolean) If connected
    ///     "addresses" : [
    ///        {
    ///          "address" : "192.168.0.201:8333",  (string) The MultiChain server host and port
    ///          "connected" : "outbound"           (string) connection, inbound or outbound
    ///        }
    ///        ,...
    ///      ]
    ///   }
    ///   ,...
    /// ]
    /// </summary>
    public class GetAddNodeInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addednode")]
        public string AddedNode { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connected")]
        public bool Connected { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public GetAddNodeInfoAddress[] Addresses { get; set; } = new GetAddNodeInfoAddress[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetAddNodeInfoAddress
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connected")]
        public string Connected { get; set; } = string.Empty;
    }
}