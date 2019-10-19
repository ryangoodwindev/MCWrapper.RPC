using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Ledger.Clients.Blockchain;
using MCWrapper.RPC.Ledger.Clients.Control;
using MCWrapper.RPC.Ledger.Clients.Generate;
using MCWrapper.RPC.Ledger.Clients.Mining;
using MCWrapper.RPC.Ledger.Clients.Network;
using MCWrapper.RPC.Ledger.Clients.OffChain;
using MCWrapper.RPC.Ledger.Clients.Raw;
using MCWrapper.RPC.Ledger.Clients.Utility;
using MCWrapper.RPC.Ledger.Clients.Wallet;
using MCWrapper.RPC.Ledger.Factory;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;

namespace MCWrapper.RPC.Extensions
{
    public static class MultiChainCoreRpcServices
    {
        /// <summary>
        /// Add MultiChain Remote Procedure Call (RPC) services to an application's service container.
        /// <para>
        ///     Be aware a MultiChain blockchain network must be installed and configured externally from this application.
        /// </para>
        /// <para>
        ///     The MultiChain library and installation instructions are availabale at https://multichain.com
        /// </para>
        /// <para>
        ///     This method automatically loads the BlockchainProfileOptions and RuntimeParamOptions from the
        ///     local environment variable store.
        /// </para>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreRPCServices(this IServiceCollection services)
        {
            // load Options from the local environment variable store
            services.Configure<RuntimeParamOptions>(config => new RuntimeParamOptions());
            services.Configure<BlockchainProfileOptions>(config => new BlockchainProfileOptions());

            // typed HttpClient configuration
            services.AddHttpClient<BlockchainRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            services.AddHttpClient<ControlRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            services.AddHttpClient<GenerateRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            services.AddHttpClient<MiningRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            services.AddHttpClient<NetworkRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            services.AddHttpClient<OffChainRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            services.AddHttpClient<RawRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            services.AddHttpClient<UtilityRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            services.AddHttpClient<WalletRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create());

            // typed HttpClient factory
            services.AddTransient<RpcClientFactory>();

            return services;
        }

        /// <summary>
        /// Add MultiChain Remote Procedure Call (RPC) services to an application's service container.
        /// 
        /// <para>
        ///     Be aware a MultiChain blockchain network must be installed and configured externally from this application.
        /// </para>
        /// 
        /// <para>
        ///     The MultiChain library and installation instructions are availabale at https://multichain.com
        /// </para>
        /// 
        /// <para>
        ///     This method automatically loads the BlockchainProfileOptions and RuntimeParamOptions from the
        ///     IConfiguration interface (appsettings.json file usually).
        /// </para>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreRPCServices(this IServiceCollection services, IConfiguration configuration)
        {
            // load Options from the IConfiguration interface (appsettings.json file usually)
            services.Configure<RuntimeParamOptions>(configuration);
            services.Configure<BlockchainProfileOptions>(configuration);

            // typed HttpClient configuration
            services.AddHttpClient<BlockchainRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));
            
            services.AddHttpClient<ControlRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));
            
            services.AddHttpClient<GenerateRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));
            
            services.AddHttpClient<MiningRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));
            
            services.AddHttpClient<NetworkRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));
           
            services.AddHttpClient<OffChainRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));
            
            services.AddHttpClient<RawRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));
           
            services.AddHttpClient<UtilityRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));
            
            services.AddHttpClient<WalletRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(configuration));

            // typed HttpClient factory
            services.AddTransient<RpcClientFactory>();

            return services;
        }


        /// <summary>
        /// Add MultiChain Remote Procedure Call (RPC) services to an application's service container.
        /// 
        /// <para>
        ///     Be aware a MultiChain blockchain network must be installed and configured externally from this application.
        /// </para>
        /// 
        /// <para>
        ///     The MultiChain library and installation instructions are availabale at https://multichain.com
        /// </para>
        /// 
        /// <para>
        ///     This method requires the BlockchainProfileOptions and RuntimeParamOptions property values to be
        ///     explicitly passed via the <paramref name="runtimeConfig"/> and <paramref name="profileConfig"/> 
        ///     Action parameters when added to the DI pipeline.
        /// </para>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="profileConfig"></param>
        /// <param name="runtimeConfig"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreRPCServices(this IServiceCollection services, Action<BlockchainProfileOptions> profileConfig, [Optional] Action<RuntimeParamOptions> runtimeConfig)
        {
            // invoke Actions
            var profile = new BlockchainProfileOptions();
            profileConfig?.Invoke(profile);

            var runtime = new RuntimeParamOptions();
            runtimeConfig?.Invoke(runtime);

            // configure BlockchainProfileOptions
            services.Configure<BlockchainProfileOptions>(config =>
            {
                config.ChainName = profile.ChainName;
                config.ChainUseSsl = profile.ChainUseSsl;
                config.ChainRpcPort = profile.ChainRpcPort;
                config.ChainSslPath = profile.ChainSslPath;
                config.ChainHostname = profile.ChainHostname;
                config.ChainPassword = profile.ChainPassword;
                config.ChainUsername = profile.ChainUsername;
                config.ChainBurnAddress = profile.ChainBurnAddress;
                config.ChainAdminAddress = profile.ChainAdminAddress;
                config.ChainBinaryLocation = profile.ChainBinaryLocation;
                config.ChainDefaultLocation = profile.ChainDefaultLocation;
                config.ChainDefaultColdNodeLocation = profile.ChainDefaultColdNodeLocation;
            });

            // configure RuntimeParamOptions
            services.Configure<RuntimeParamOptions>(config =>
            {
                config.BanTx = runtime.BanTx;
                config.LockBlock = runtime.LockBlock;
                config.MaxShownData = runtime.MaxShownData;
                config.AutoSubscribe = runtime.AutoSubscribe;
                config.MiningTurnOver = runtime.MiningTurnOver;
                config.HandshakeLocal = runtime.HandshakeLocal;
                config.MineEmptyRounds = runtime.MineEmptyRounds;
                config.HideKnownOpDrops = runtime.HideKnownOpDrops;
                config.MaxQueryScanItems = runtime.MaxQueryScanItems;
                config.MiningRequiresPeers = runtime.MiningRequiresPeers;
                config.LockAdminMineRounds = runtime.LockAdminMineRounds;
            });

            // typed HttpClient configuration
            services.AddHttpClient<BlockchainRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));
            
            services.AddHttpClient<ControlRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));
            
            services.AddHttpClient<GenerateRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));
            
            services.AddHttpClient<MiningRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));
            
            services.AddHttpClient<NetworkRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));
            
            services.AddHttpClient<OffChainRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));
            
            services.AddHttpClient<RawRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));
           
            services.AddHttpClient<UtilityRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));
            
            services.AddHttpClient<WalletRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => RpcMessageHandler.Create(profile));

            // typed HttpClient factory
            services.AddTransient<RpcClientFactory>();

            return services;
        }
    }
}