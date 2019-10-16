using MCWrapper.RPC.Extensions;

namespace MCWrapper.RPC.Options
{
    /// <summary>
    /// RuntimeParamOption values can be used to initiate a blockchain on startup
    /// MCWrapper doesn't provide the logic for doing so at this time, users wishing
    /// to initialize their runtime params via the RuntimeParamOptions pipeline will
    /// be required to do so via the MCWrapper CLI or RPC client methods associated
    /// with this task (i.e. setruntimeparam blockchain method via either client)
    /// 
    /// <para>
    ///     Neither the MCWrapper RPC nor the CLI client require RuntimeParamOptions to function normally.
    ///     RuntimeParamOptions are purely optional at this time.
    /// </para>
    /// </summary>
    public class RuntimeParamOptions
    {
        /// <summary>
        /// Create a new RuntimeParamOptions object
        /// No arguments
        /// </summary>
        public RuntimeParamOptions() { }

        /// <summary>
        /// A comma-delimited list of txids for transactions that should not be accepted by the node. 
        /// Any new incoming block containing one of these transactions will also be considered invalid, 
        /// but previously accepted and verified blocks will not be affected.
        /// </summary>
        public string BanTx
        {
            get => !string.IsNullOrEmpty(_banTx) ? _banTx
                : nameof(BanTx).GetEnvironmentVariable() ?? string.Empty;

            set => _banTx = value;
        }
        private string _banTx = string.Empty;

        /// <summary>
        /// Blocks on branches without this block (passed as a block hash) will be rejected. 
        /// This allows a particular branch of a chain to be manually selected.
        /// </summary>
        public string LockBlock
        {
            get => !string.IsNullOrEmpty(_lockBlock) ? _lockBlock
                : nameof(LockBlock).GetEnvironmentVariable() ?? string.Empty;

            set => _lockBlock = value;
        }
        private string _lockBlock = string.Empty;

        /// <summary>
        /// The maximum number of bytes to show in the data field of API responses. 
        /// Pieces of data larger than this will be returned as an object with txid, vout and size fields, 
        /// for use with the gettxoutdata command.
        /// </summary>
        public string MaxShownData
        {
            get => !string.IsNullOrEmpty(_maxShownData) ? _maxShownData
                : nameof(MaxShownData).GetEnvironmentVariable() ?? string.Empty;

            set => _maxShownData = value;
        }
        private string _maxShownData = string.Empty;

        /// <summary>
        /// Set this parameter to assets, streams or assets,streams to automatically subscribe to every 
        /// new asset and/or stream created on the blockchain, without requiring use of the subscribe command.
        /// </summary>
        public string AutoSubscribe
        {
            get => !string.IsNullOrEmpty(_autoSubscribe) ? _autoSubscribe
                : nameof(AutoSubscribe).GetEnvironmentVariable() ?? string.Empty;

            set => _autoSubscribe = value;
        }
        private string _autoSubscribe = string.Empty;

        /// <summary>
        /// Manually override the wallet address which is used for handshaking with other peers in a MultiChain 
        /// blockchain. This is helpful if the address previously used for handshaking has lost connect 
        /// permissions, and the node does not yet know which of its other addresses to use, 
        /// because it has been disconnected from the chain.
        /// </summary>
        public string HandshakeLocal
        {
            get => !string.IsNullOrEmpty(_handshakeLocal) ? _handshakeLocal
                : nameof(HandshakeLocal).GetEnvironmentVariable() ?? string.Empty;

            set => _handshakeLocal = value;
        }
        private string _handshakeLocal = string.Empty;

        /// <summary>
        /// Remove recognized MultiChain OP_DROP metadata from the responses to calls like decoderawtransaction,
        /// decodescript, getrawtransaction, gettxout and listunspent which show the content of transaction 
        /// output scripts, whether in raw hexadecimal or decoded form. This option is provided to help with 
        /// backwards compatibility for tools built on Bitcoin Core, which get confused by this metadata.
        /// </summary>
        public string HideKnownOpDrops
        {
            get => !string.IsNullOrEmpty(_hideKnownOpDrops) ? _hideKnownOpDrops
                : nameof(HideKnownOpDrops).GetEnvironmentVariable() ?? string.Empty;

            set => _hideKnownOpDrops = value;
        }
        private string _hideKnownOpDrops = string.Empty;

        /// <summary>
        /// The maximum number of transactions to decode for a querying request (currently liststreamqueryitems).
        /// </summary>
        public string MaxQueryScanItems
        {
            get => !string.IsNullOrEmpty(_maxQueryScanItems) ? _maxQueryScanItems
                : nameof(MaxQueryScanItems).GetEnvironmentVariable() ?? string.Empty;

            set => _maxQueryScanItems = value;
        }
        private string _maxQueryScanItems = string.Empty;

        /// <summary>
        /// These override the recommendations provided by the lock-admin-mine-rounds, 
        /// mining-requires-peers, mine-empty-rounds and mining-turnover blockchain parameters, 
        /// and should be used with caution. https://www.multichain.com/developers/blockchain-parameters/
        /// </summary>
        public string MiningTurnOver
        {
            get => !string.IsNullOrEmpty(_miningTurnOver) ? _miningTurnOver
                : nameof(MiningTurnOver).GetEnvironmentVariable() ?? string.Empty;

            set => _miningTurnOver = value;
        }
        private string _miningTurnOver = string.Empty;

        /// <summary>
        /// Each node independently decides, based on its mineemptyrounds runtime parameter, whether it is valid to keep buliding blocks on the chain or not
        /// </summary>
        public string MineEmptyRounds
        {
            get => !string.IsNullOrEmpty(_mineEmptyRounds) ? _mineEmptyRounds
                : nameof(MineEmptyRounds).GetEnvironmentVariable() ?? string.Empty;

            set => _mineEmptyRounds = value;
        }
        private string _mineEmptyRounds = string.Empty;

        /// <summary>
        /// Ignore forks that reverse changes in admin or mine permissions after this many (integer) rounds have passed
        /// </summary>
        public string LockAdminMineRounds
        {
            get => !string.IsNullOrEmpty(_lockAdminMineRounds) ? _lockAdminMineRounds
                : nameof(LockAdminMineRounds).GetEnvironmentVariable() ?? string.Empty;

            set => _lockAdminMineRounds = value;
        }
        private string _lockAdminMineRounds = string.Empty;

        /// <summary>
        /// Indicates whether peers must be connected to the blockchain network in order for block mining to occur
        /// </summary>
        public string MiningRequiresPeers
        {
            get => !string.IsNullOrEmpty(_miningRequiresPeers) ? _miningRequiresPeers
                : nameof(MiningRequiresPeers).GetEnvironmentVariable() ?? string.Empty;

            set => _miningRequiresPeers = value;
        }
        private string _miningRequiresPeers = string.Empty;
    }
}
