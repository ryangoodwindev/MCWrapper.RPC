using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Control
{
    /// <summary>
    /// Result:
    /// {
    ///   "version": xxxxx,                 (numeric) the server version
    ///   "protocolversion": xxxxx,         (numeric) the protocol version
    ///   "chainname": "xxxx",              (string) multichain network name
    ///   "description": "xxxx",            (string) network desctription
    ///   "protocol": "xxxx",               (string) protocol - multichain or bitcoin
    ///   "port": xxxx,                     (numeric) network port
    ///   "setupblocks": "xxxx",            (string) number of network setup blocks
    ///   "walletversion": xxxxx,           (numeric) the wallet version
    ///   "balance": xxxxxxx,               (numeric) the total native currency balance of the wallet
    ///   "walletdbversion": xxxxx,         (numeric) the wallet database version
    ///   "blocks": xxxxxx,                 (numeric) the current number of blocks processed in the server
    ///   "timeoffset": xxxxx,              (numeric) the time offset
    ///   "connections": xxxxx,             (numeric) the number of connections
    ///   "proxy": "host:port",             (string, optional) the proxy used by the server
    ///   "difficulty": xxxxxx,             (numeric) the current difficulty
    ///   "testnet": true|false,            (boolean) if the server is using testnet or not
    ///   "keypoololdest": xxxxxx,          (numeric) the timestamp (seconds since GMT epoch) of the oldest pre-generated key in the key pool
    ///   "keypoolsize": xxxx,              (numeric) how many new keys are pre-generated
    ///   "unlocked_until": ttt,            (numeric) the timestamp in seconds since epoch (midnight Jan 1 1970 GMT) that the wallet is unlocked for transfers, or 0 if the wallet is locked
    ///   "paytxfee": x.xxxx,               (numeric) the transaction fee set in btc/kb
    ///   "relayfee": x.xxxx,               (numeric) minimum relay fee for non-free transactions in btc/kb
    ///   "errors": "..."                   (string) any error messages
    /// }
    /// </summary>
    public class GetInfoResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nodeversion")]
        public int NodeVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("protocolversion")]
        public int ProtocolVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainname")]
        public string ChainName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("setupblocks")]
        public int SetupBlocks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nodeaddress")]
        public string NodeAddress { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("burnaddress")]
        public string BurnAddress { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("incomingpaused")]
        public bool IncomingPaused { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miningpaused")]
        public bool MiningPaused { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("offchainpaused")]
        public bool OffChainPaused { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("walletversion")]
        public int WalletVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public float Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("walletdbversion")]
        public int WalletDbVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reindex")]
        public bool ReIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blocks")]
        public int Blocks { get; set; }

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
        [JsonProperty("proxy")]
        public string Proxy { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("difficulty")]
        public float Difficulty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("testnet")]
        public bool TestNet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("keypoololdest")]
        public int KeyPoolOldest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("keypoolsize")]
        public int KeyPoolSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("paytxfee")]
        public float PayTxFee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("relayfee")]
        public float RelayFee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("errors")]
        public string Errors { get; set; } = string.Empty;
    }
}
