namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// MultiChainRpcClientFactory provides access to a collection of MultiChainRpcClients
    /// </summary>
    public interface IMultiChainRpcClientFactory
    {
        /// <summary>
        /// Get a required IMultiChainRpc instance. Must be derived from IMultiChainRpc
        /// 
        /// <para>Options available:</para>
        /// <para>
        ///     IMultiChainRpcGenerate, IMultiChainRpcOffChain, IMultiChainRpcControl, IMultiChainRpcGeneral,
        ///     IMultiChainRpcNetwork, IMultiChainRpcUtility, IMultiChainRpcMining, IMultiChainRpcWallet,
        ///     IMultiChainRpcRaw
        /// </para>
        /// 
        /// </summary>
        /// <typeparam name="IMultiChainRpc">Return a service derived from IMultiChainRpc</typeparam>
        /// <returns></returns>
        IMultiChainRpc GetRequiredRpcClient<IMultiChainRpc>();

        /// <summary>
        /// Provides access to Generate (native currency or coins) MultChain Core methods
        /// </summary>
        IMultiChainRpcGenerate MultiChainRpcGenerateClient { get; }

        /// <summary>
        /// Provides access to OffChain MultChain Core methods
        /// </summary>
        IMultiChainRpcOffChain BlockchainRpcOffChainClient { get; }

        /// <summary>
        /// Provides access to Control MultChain Core methods
        /// </summary>
        IMultiChainRpcControl BlockchainRpcControlClient { get; }

        /// <summary>
        /// Provides access to General MultChain Core methods
        /// </summary>
        IMultiChainRpcGeneral BlockchainRpcGeneralClient { get; }

        /// <summary>
        /// Provides access to Network MultChain Core methods
        /// </summary>
        IMultiChainRpcNetwork BlockchainRpcNetworkClient { get; }

        /// <summary>
        /// Provides access to Utility MultChain Core methods
        /// </summary>
        IMultiChainRpcUtility BlockchainRpcUtilityClient { get; }

        /// <summary>
        /// Provides access to Mining MultChain Core methods
        /// </summary>
        IMultiChainRpcMining BlockchainRpcMiningClient { get; }

        /// <summary>
        /// Provides access to Wallet MultChain Core methods
        /// </summary>
        IMultiChainRpcWallet BlockchainRpcWalletClient { get; }

        /// <summary>
        /// Provides access to Raw MultChain Core methods
        /// </summary>
        IMultiChainRpcRaw BlockchainRpcRawClient { get; }
    }
}