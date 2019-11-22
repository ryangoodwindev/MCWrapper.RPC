using System;
using System.Collections.Generic;

namespace MCWrapper.RPC.Ledger.Clients
{
    public class RpcClientFactory : IRpcClientFactory
    {
        private readonly Dictionary<Type, IRpcContract> _services = new Dictionary<Type, IRpcContract>();

        public RpcClientFactory(IBlockchainRpc blockchainRpc,
            IBlockchainRpcControl blockchainRpcControl,
            IBlockchainRpcGenerate blockchainRpcGenerate,
            IBlockchainRpcMining blockchainRpcMining,
            IBlockchainRpcNetwork blockchainRpcNetwork,
            IBlockchainRpcOffChain blockchainRpcOffChain,
            IBlockchainRpcRaw blockchainRpcRaw,
            IBlockchainRpcUtility blockchainRpcUtility,
            IBlockchainRpcWallet blockchainRpcWallet)
        {
            _services.Add(typeof(IBlockchainRpc), blockchainRpc);
            _services.Add(typeof(IBlockchainRpcControl), blockchainRpcControl);
            _services.Add(typeof(IBlockchainRpcGenerate), blockchainRpcGenerate);
            _services.Add(typeof(IBlockchainRpcMining), blockchainRpcMining);
            _services.Add(typeof(IBlockchainRpcNetwork), blockchainRpcNetwork);
            _services.Add(typeof(IBlockchainRpcOffChain), blockchainRpcOffChain);
            _services.Add(typeof(IBlockchainRpcRaw), blockchainRpcRaw);
            _services.Add(typeof(IBlockchainRpcUtility), blockchainRpcUtility);
            _services.Add(typeof(IBlockchainRpcWallet), blockchainRpcWallet);
        }

        public T GetRpcClient<T>()
        {
            return (T)_services[typeof(T)];
        }
    }
}