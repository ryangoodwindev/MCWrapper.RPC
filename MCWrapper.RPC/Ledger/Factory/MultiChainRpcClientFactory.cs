using System;
using System.Collections.Generic;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// MultiChainRpcClientFactory provides access to a collection of MultiChainRpcClients
    /// </summary>
    public class MultiChainRpcClientFactory : IMultiChainRpcClientFactory
    {
        private readonly Dictionary<Type, IMultiChainRpc> _clients;

        /// <summary>
        /// MultiChainRpcClientFactory provides access to a collection of MultiChainRpcClients
        /// </summary>
        /// <param name="multiChainRpcGenerate">Provides access to Generate (native currency or coins) MultChain Core methods</param>
        /// <param name="blockchainRpcOffChain">Provides access to OffChain MultChain Core methods</param>
        /// <param name="blockchainRpcControl">Provides access to Control MultChain Core methods</param>
        /// <param name="blockchainRpcGeneral">Provides access to General MultChain Core methods</param>
        /// <param name="blockchainRpcNetwork">Provides access to Network MultChain Core methods</param>
        /// <param name="blockchainRpcUtility">Provides access to Utility MultChain Core methods</param>
        /// <param name="blockchainRpcMining">Provides access to Mining MultChain Core methods</param>
        /// <param name="blockchainRpcWallet">Provides access to Waller MultChain Core methods</param>
        /// <param name="blockchainRpcRaw">Provides access to Raw MultChain Core methods</param>
        public MultiChainRpcClientFactory(IMultiChainRpcGenerate multiChainRpcGenerate,
            IMultiChainRpcOffChain blockchainRpcOffChain,
            IMultiChainRpcControl blockchainRpcControl,
            IMultiChainRpcGeneral blockchainRpcGeneral,
            IMultiChainRpcNetwork blockchainRpcNetwork,
            IMultiChainRpcUtility blockchainRpcUtility,
            IMultiChainRpcMining blockchainRpcMining,
            IMultiChainRpcWallet blockchainRpcWallet,
            IMultiChainRpcRaw blockchainRpcRaw)
        {
            _clients = new Dictionary<Type, IMultiChainRpc>();

            _blockchainRpcGenerate = multiChainRpcGenerate;
            _clients.TryAdd(typeof(IMultiChainRpcGenerate), multiChainRpcGenerate);

            _blockchainRpcOffChain = blockchainRpcOffChain;
            _clients.TryAdd(typeof(IMultiChainRpcOffChain), blockchainRpcOffChain);

            _blockchainRpcControl = blockchainRpcControl;
            _clients.TryAdd(typeof(IMultiChainRpcControl), blockchainRpcControl);

            _blockchainRpcGeneral = blockchainRpcGeneral;
            _clients.TryAdd(typeof(IMultiChainRpcGeneral), blockchainRpcGeneral);

            _blockchainRpcNetwork = blockchainRpcNetwork;
            _clients.TryAdd(typeof(IMultiChainRpcNetwork), blockchainRpcNetwork);

            _blockchainRpcUtility = blockchainRpcUtility;
            _clients.TryAdd(typeof(IMultiChainRpcUtility), blockchainRpcUtility);

            _blockchainRpcMining = blockchainRpcMining;
            _clients.TryAdd(typeof(IMultiChainRpcMining), blockchainRpcMining);

            _blockchainRpcWallet = blockchainRpcWallet;
            _clients.TryAdd(typeof(IMultiChainRpcWallet), blockchainRpcWallet);

            _blockchainRpcRaw = blockchainRpcRaw;
            _clients.TryAdd(typeof(IMultiChainRpcRaw), blockchainRpcRaw);
        }

        /// <summary>
        /// Get a required MultiChainRpcClient
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetRequiredRpcClient<T>() => 
            (T)_clients[typeof(T)];

        /// <summary>
        /// Provides access to Generate (native currency or coins) MultChain Core methods
        /// </summary>
        public IMultiChainRpcGenerate MultiChainRpcGenerateClient => _blockchainRpcGenerate;
        private readonly IMultiChainRpcGenerate _blockchainRpcGenerate;

        /// <summary>
        /// Provides access to OffChain MultChain Core methods
        /// </summary>
        public IMultiChainRpcOffChain BlockchainRpcOffChainClient => _blockchainRpcOffChain;
        private readonly IMultiChainRpcOffChain _blockchainRpcOffChain;

        /// <summary>
        /// Provides access to Control MultChain Core methods
        /// </summary>
        public IMultiChainRpcControl BlockchainRpcControlClient => _blockchainRpcControl;
        private readonly IMultiChainRpcControl _blockchainRpcControl;

        /// <summary>
        /// Provides access to General MultChain Core methods
        /// </summary>
        public IMultiChainRpcGeneral BlockchainRpcGeneralClient => _blockchainRpcGeneral;
        private readonly IMultiChainRpcGeneral _blockchainRpcGeneral;

        /// <summary>
        /// Provides access to Network MultChain Core methods
        /// </summary>
        public IMultiChainRpcNetwork BlockchainRpcNetworkClient => _blockchainRpcNetwork;
        private readonly IMultiChainRpcNetwork _blockchainRpcNetwork;

        /// <summary>
        /// Provides access to Utility MultChain Core methods
        /// </summary>
        public IMultiChainRpcUtility BlockchainRpcUtilityClient => _blockchainRpcUtility;
        private readonly IMultiChainRpcUtility _blockchainRpcUtility;

        /// <summary>
        /// Provides access to Mining MultChain Core methods
        /// </summary>
        public IMultiChainRpcMining BlockchainRpcMiningClient => _blockchainRpcMining;
        private readonly IMultiChainRpcMining _blockchainRpcMining;

        /// <summary>
        /// Provides access to Wallet MultChain Core methods
        /// </summary>
        public IMultiChainRpcWallet BlockchainRpcWalletClient => _blockchainRpcWallet;
        private readonly IMultiChainRpcWallet _blockchainRpcWallet;

        /// <summary>
        /// Provides access to Raw MultChain Core methods
        /// </summary>
        public IMultiChainRpcRaw BlockchainRpcRawClient => _blockchainRpcRaw;
        private readonly IMultiChainRpcRaw _blockchainRpcRaw;
    }
}