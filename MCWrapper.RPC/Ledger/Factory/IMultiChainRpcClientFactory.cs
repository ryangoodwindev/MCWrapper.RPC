namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IMultiChainRpcClientFactory
    {
        IMultiChainRpcGeneral BlockchainRpcGeneralClient { get; }
        IMultiChainRpcControl BlockchainRpcControlClient { get; }
        IMultiChainRpcGenerate BlockchainRpcGenerateClient { get; }
        IMultiChainRpcMining BlockchainRpcMiningClient { get; }
        IMultiChainRpcNetwork BlockchainRpcNetworkClient { get; }
        IMultiChainRpcOffChain BlockchainRpcOffChainClient { get; }
        IMultiChainRpcRaw BlockchainRpcRawClient { get; }
        IMultiChainRpcUtility BlockchainRpcUtilityClient { get; }
        IMultiChainRpcWallet BlockchainRpcWalletClient { get; }

        T GetRequiredRpcClient<T>();
    }
}