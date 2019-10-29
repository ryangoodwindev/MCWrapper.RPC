namespace MCWrapper.RPC.Ledger.Clients
{
    public class RpcClientFactory
    {
        public RpcClientFactory(BlockchainRpcClient blockchainClient, GenerateRpcClient generateClient, OffChainRpcClient offChainClient,
            ControlRpcClient controlClient, NetworkRpcClient networkClient, UtilityRpcClient utilityClient, MiningRpcClient miningClient,
            WalletRpcClient walletClient, RawRpcClient rawClient)
        {
            BlockchainClient = blockchainClient;
            GenerateClient = generateClient;
            OffChainClient = offChainClient;
            ControlClient = controlClient;
            NetworkClient = networkClient;
            UtilityClient = utilityClient;
            MiningClient = miningClient;
            WalletClient = walletClient;
            RawClient = rawClient;
        }

        public BlockchainRpcClient BlockchainRpcClient => BlockchainClient;
        private readonly BlockchainRpcClient BlockchainClient;

        public GenerateRpcClient GenerateRpcClient => GenerateClient;
        private readonly GenerateRpcClient GenerateClient;

        public OffChainRpcClient OffChainRpcClient => OffChainClient;
        private readonly OffChainRpcClient OffChainClient;

        public ControlRpcClient ControlRpcClient => ControlClient;
        private readonly ControlRpcClient ControlClient;

        public NetworkRpcClient NetworkRpcClient => NetworkClient;
        private readonly NetworkRpcClient NetworkClient;

        public UtilityRpcClient UtilityRpcClient => UtilityClient;
        private readonly UtilityRpcClient UtilityClient;

        public MiningRpcClient MiningRpcClient => MiningClient;
        private readonly MiningRpcClient MiningClient;

        public WalletRpcClient WalletRpcClient => WalletClient;
        private readonly WalletRpcClient WalletClient;

        public RawRpcClient RawRpcClient => RawClient;
        private readonly RawRpcClient RawClient;
    }
}