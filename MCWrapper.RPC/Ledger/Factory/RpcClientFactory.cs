using MCWrapper.RPC.Ledger.Clients.Blockchain;
using MCWrapper.RPC.Ledger.Clients.Control;
using MCWrapper.RPC.Ledger.Clients.Generate;
using MCWrapper.RPC.Ledger.Clients.Mining;
using MCWrapper.RPC.Ledger.Clients.Network;
using MCWrapper.RPC.Ledger.Clients.OffChain;
using MCWrapper.RPC.Ledger.Clients.Raw;
using MCWrapper.RPC.Ledger.Clients.Utility;
using MCWrapper.RPC.Ledger.Clients.Wallet;

namespace MCWrapper.RPC.Ledger.Factory
{
    public class RpcClientFactory
    {
        private readonly BlockchainRpcClient Blockchain;
        private readonly GenerateRpcClient Generate;
        private readonly OffChainRpcClient OffChain;
        private readonly ControlRpcClient Control;
        private readonly NetworkRpcClient Network;
        private readonly UtilityRpcClient Utility;
        private readonly MiningRpcClient Mining;
        private readonly WalletRpcClient Wallet;
        private readonly RawRpcClient Raw;

        public RpcClientFactory(BlockchainRpcClient blockchain, GenerateRpcClient generate, OffChainRpcClient offChain,
            ControlRpcClient control, NetworkRpcClient network, UtilityRpcClient utility, MiningRpcClient mining,
            WalletRpcClient wallet, RawRpcClient raw)
        {
            Blockchain = blockchain;
            Generate = generate;
            OffChain = offChain;
            Control = control;
            Network = network;
            Utility = utility;
            Mining = mining;
            Wallet = wallet;
            Raw = raw;
        }

        public BlockchainRpcClient GetBlockchainRpcClient() => Blockchain;

        public GenerateRpcClient GetGenerateRpcClient() => Generate;

        public OffChainRpcClient GetOffChainRpcClient() => OffChain;

        public ControlRpcClient GetControlRpcClient() => Control;

        public NetworkRpcClient GetNetworkRpcClient() => Network;

        public UtilityRpcClient GetUtilityRpcClient() => Utility;

        public MiningRpcClient GetMiningRpcClient() => Mining;

        public WalletRpcClient GetWalletRpcClient() => Wallet;

        public RawRpcClient GetRawRpcClient() => Raw;
    }
}