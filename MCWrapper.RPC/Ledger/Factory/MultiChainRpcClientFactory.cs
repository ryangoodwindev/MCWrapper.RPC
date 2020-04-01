using System;
using System.Collections.Generic;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// MultiChainRpcClientFactory provides access to a collection of MultiChainRpcClients
    /// </summary>
    public class MultiChainRpcClientFactory : IMultiChainRpcClientFactory
    {
        // collection of Rpc clients
        private readonly Dictionary<Type, IMultiChainRpc> _clients;

        /// <summary>
        /// MultiChainRpcClientFactory provides access to a collection of MultiChainRpcClients
        /// </summary>
        /// <param name="multiChainRpcGenerate">Provides access to Generate (native currency or coins) MultChain Core methods</param>
        /// <param name="multiChainRpcOffChain">Provides access to OffChain MultChain Core methods</param>
        /// <param name="multiChainRpcControl">Provides access to Control MultChain Core methods</param>
        /// <param name="multiChainRpcGeneral">Provides access to General MultChain Core methods</param>
        /// <param name="multiChainRpcNetwork">Provides access to Network MultChain Core methods</param>
        /// <param name="multiChainRpcUtility">Provides access to Utility MultChain Core methods</param>
        /// <param name="multiChainRpcMining">Provides access to Mining MultChain Core methods</param>
        /// <param name="multiChainRpcWallet">Provides access to Waller MultChain Core methods</param>
        /// <param name="multiChainRpcRaw">Provides access to Raw MultChain Core methods</param>
        public MultiChainRpcClientFactory(IMultiChainRpcGenerate multiChainRpcGenerate,
            IMultiChainRpcOffChain multiChainRpcOffChain,
            IMultiChainRpcControl multiChainRpcControl,
            IMultiChainRpcGeneral multiChainRpcGeneral,
            IMultiChainRpcNetwork multiChainRpcNetwork,
            IMultiChainRpcUtility multiChainRpcUtility,
            IMultiChainRpcMining multiChainRpcMining,
            IMultiChainRpcWallet multiChainRpcWallet,
            IMultiChainRpcRaw multiChainRpcRaw)
        {
            _clients = new Dictionary<Type, IMultiChainRpc>();

            _blockchainRpcGenerate = multiChainRpcGenerate;
            _clients.Add(typeof(IMultiChainRpcGenerate), multiChainRpcGenerate);

            _blockchainRpcOffChain = multiChainRpcOffChain;
            _clients.Add(typeof(IMultiChainRpcOffChain), multiChainRpcOffChain);

            _blockchainRpcControl = multiChainRpcControl;
            _clients.Add(typeof(IMultiChainRpcControl), multiChainRpcControl);

            _blockchainRpcGeneral = multiChainRpcGeneral;
            _clients.Add(typeof(IMultiChainRpcGeneral), multiChainRpcGeneral);

            _blockchainRpcNetwork = multiChainRpcNetwork;
            _clients.Add(typeof(IMultiChainRpcNetwork), multiChainRpcNetwork);

            _blockchainRpcUtility = multiChainRpcUtility;
            _clients.Add(typeof(IMultiChainRpcUtility), multiChainRpcUtility);

            _blockchainRpcMining = multiChainRpcMining;
            _clients.Add(typeof(IMultiChainRpcMining), multiChainRpcMining);

            _blockchainRpcWallet = multiChainRpcWallet;
            _clients.Add(typeof(IMultiChainRpcWallet), multiChainRpcWallet);

            _blockchainRpcRaw = multiChainRpcRaw;
            _clients.Add(typeof(IMultiChainRpcRaw), multiChainRpcRaw);
        }

        /// <summary>
        /// Get a required MultiChainRpcClient
        /// </summary>
        /// <typeparam name="IMultiChainRpc"></typeparam>
        /// <returns></returns>
        public IMultiChainRpc GetRequiredRpcClient<IMultiChainRpc>() => 
            (IMultiChainRpc)_clients[typeof(IMultiChainRpc)];

        /// <summary>
        /// Provides access to Generate (native currency or coins) MultChain Core methods
        /// </summary>
        public IMultiChainRpcGenerate MultiChainRpcGenerateClient => _blockchainRpcGenerate;
        private readonly IMultiChainRpcGenerate _blockchainRpcGenerate;

        /// <summary>
        /// Provides access to OffChain MultChain Core methods
        /// </summary>
        public IMultiChainRpcOffChain MultiChainRpcOffChainClient => _blockchainRpcOffChain;
        private readonly IMultiChainRpcOffChain _blockchainRpcOffChain;

        /// <summary>
        /// Provides access to Control MultChain Core methods
        /// </summary>
        public IMultiChainRpcControl MultiChainRpcControlClient => _blockchainRpcControl;
        private readonly IMultiChainRpcControl _blockchainRpcControl;

        /// <summary>
        /// Provides access to General MultChain Core methods
        /// </summary>
        public IMultiChainRpcGeneral MultiChainRpcGeneralClient => _blockchainRpcGeneral;
        private readonly IMultiChainRpcGeneral _blockchainRpcGeneral;

        /// <summary>
        /// Provides access to Network MultChain Core methods
        /// </summary>
        public IMultiChainRpcNetwork MultiChainRpcNetworkClient => _blockchainRpcNetwork;
        private readonly IMultiChainRpcNetwork _blockchainRpcNetwork;

        /// <summary>
        /// Provides access to Utility MultChain Core methods
        /// </summary>
        public IMultiChainRpcUtility MultiChainRpcUtilityClient => _blockchainRpcUtility;
        private readonly IMultiChainRpcUtility _blockchainRpcUtility;

        /// <summary>
        /// Provides access to Mining MultChain Core methods
        /// </summary>
        public IMultiChainRpcMining MultiChainRpcMiningClient => _blockchainRpcMining;
        private readonly IMultiChainRpcMining _blockchainRpcMining;

        /// <summary>
        /// Provides access to Wallet MultChain Core methods
        /// </summary>
        public IMultiChainRpcWallet MultiChainRpcWalletClient => _blockchainRpcWallet;
        private readonly IMultiChainRpcWallet _blockchainRpcWallet;

        /// <summary>
        /// Provides access to Raw MultChain Core methods
        /// </summary>
        public IMultiChainRpcRaw MultiChainRpcRawClient => _blockchainRpcRaw;
        private readonly IMultiChainRpcRaw _blockchainRpcRaw;
    }
}