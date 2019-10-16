using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class GetNetworkInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("subversion")]
        public string SubVersion { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("protocolversion")]
        public int ProtocolVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("localservices")]
        public string LocalServices { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timeoffset")]
        public int TimeOffset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("connections")]
        public int Connections { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("networks")]
        public GetNetworkInfoNetwork[] Networks { get; set; } = new GetNetworkInfoNetwork[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("relayfee")]
        public float RelayFee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("localaddresses")]
        public GetNetworkInfoLocaladdress[] LocalAddresses { get; set; } = new GetNetworkInfoLocaladdress[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetNetworkInfoNetwork
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("limited")]
        public bool Limited { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reachable")]
        public bool Reachable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("proxy")]
        public string Proxy { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetNetworkInfoLocaladdress
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("score")]
        public int Score { get; set; }
    }
}