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
    /// <summary>
    /// Add MultiChain services to the application; Be aware the MultiChain network must be installed and configured externally from your application.
    /// The MultiChain library is availabale at https://multichain.com
    /// </summary>
    public static class MultiChainCoreServices
    {
        /// <summary>
        /// Add MultiChainServices (CLI and RPC clients) to thie application's 
        /// Dependency Injection (DI) container. 
        /// 
        /// <para>
        ///     This method loads the BlockchainProfileOptions and RuntimeParamOptions from the
        ///     local environment variable store.
        /// </para>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services)
        {
            // load RuntimeParamOptions from the local appsettings.json file
            services.Configure<RuntimeParamOptions>(config => new RuntimeParamOptions());
            // load BlockchainProfileOptions from the local appsettings.json file
            services.Configure<BlockchainProfileOptions>(config => new BlockchainProfileOptions());

            // add remote procedure call (RPC) BlockchainRPCClient
            services.AddHttpClient<BlockchainRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());
            // add remote procedure call (RPC) ControlRPCClient
            services.AddHttpClient<ControlRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());
            // add remote procedure call (RPC) GenerateRPCClient
            services.AddHttpClient<GenerateRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());
            // add remote procedure call (RPC) MineRPCClient
            services.AddHttpClient<MiningRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());
            // add remote procedure call (RPC) NetworkRPCClient
            services.AddHttpClient<NetworkRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());
            // add remote procedure call (RPC) OffChainRPCClient
            services.AddHttpClient<OffChainRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());
            // add remote procedure call (RPC) RawRPCClient
            services.AddHttpClient<RawRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());
            // add remote procedure call (RPC) UtilityRPCClient
            services.AddHttpClient<UtilityRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());
            // add remote procedure call (RPC) WalletRPCClient
            services.AddHttpClient<WalletRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create());

            services.AddTransient<RpcClientFactory>();

            // return service collection to subscriber
            return services;
        }

        /// <summary>
        /// Add MultiChainServices (CLI and RPC clients) to thie application's 
        /// Dependency Injection (DI) container. 
        /// 
        /// <para>
        ///     This method loads the BlockchainProfileOptions and RuntimeParamOptions from the
        ///     IConfiguration pipeline (i.e. appsettings.json file).
        /// </para>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            // load RuntimeParamOptions from the local appsettings.json file
            services.Configure<RuntimeParamOptions>(configuration);
            // load BlockchainProfileOptions from the local appsettings.json file
            services.Configure<BlockchainProfileOptions>(configuration);

            // add remote procedure call (RPC) BlockchainRPCClient
            services.AddHttpClient<BlockchainRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));
            // add remote procedure call (RPC) ControlRPCClient
            services.AddHttpClient<ControlRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));
            // add remote procedure call (RPC) GenerateRPCClient
            services.AddHttpClient<GenerateRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));
            // add remote procedure call (RPC) MineRPCClient
            services.AddHttpClient<MiningRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));
            // add remote procedure call (RPC) NetworkRPCClient
            services.AddHttpClient<NetworkRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));
            // add remote procedure call (RPC) OffChainRPCClient
            services.AddHttpClient<OffChainRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));
            // add remote procedure call (RPC) RawRPCClient
            services.AddHttpClient<RawRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));
            // add remote procedure call (RPC) UtilityRPCClient
            services.AddHttpClient<UtilityRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));
            // add remote procedure call (RPC) WalletRPCClient
            services.AddHttpClient<WalletRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(configuration));

            services.AddTransient<RpcClientFactory>();

            // return service collection to subscriber
            return services;
        }

        /// <summary>
        /// Add MultiChainServices (CLI and RPC clients) to thie application's 
        /// Dependency Injection (DI) container. 
        /// 
        /// <para>
        ///     This method requires the BlockchainProfileOptions and RuntimeParamOptions property values to be
        ///     manually configured via the <paramref name="runtimeConfig"/> and <paramref name="profileConfig"/> 
        ///     Action parameters when added to the DI pipeline.
        /// </para>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="profileConfig"></param>
        /// <param name="runtimeConfig"></param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreServices(this IServiceCollection services, Action<BlockchainProfileOptions> profileConfig, [Optional] Action<RuntimeParamOptions> runtimeConfig)
        {
            // invoke object and properties from Action<>
            var profile = new BlockchainProfileOptions();
            profileConfig?.Invoke(profile);

            // manually load BlockchainProfileOptions property values
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

            // invoke object and properties from Action<>
            var runtime = new RuntimeParamOptions();
            if (runtimeConfig != null)
                runtimeConfig?.Invoke(runtime);

            // manually load RuntimeParamOptions property values
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

            // add remote procedure call (RPC) BlockchainRPCClient
            services.AddHttpClient<BlockchainRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));
            // add remote procedure call (RPC) ControlRPCClient
            services.AddHttpClient<ControlRpcClient>()
                .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));
            // add remote procedure call (RPC) GenerateRPCClient
            services.AddHttpClient<GenerateRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));
            // add remote procedure call (RPC) MineRPCClient
            services.AddHttpClient<MiningRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));
            // add remote procedure call (RPC) NetworkRPCClient
            services.AddHttpClient<NetworkRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));
            // add remote procedure call (RPC) OffChainRPCClient
            services.AddHttpClient<OffChainRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));
            // add remote procedure call (RPC) RawRPCClient
            services.AddHttpClient<RawRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));
            // add remote procedure call (RPC) UtilityRPCClient
            services.AddHttpClient<UtilityRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));
            // add remote procedure call (RPC) WalletRPCClient
            services.AddHttpClient<WalletRpcClient>()
               .ConfigurePrimaryHttpMessageHandler(() => MessageHandler.Create(profile));

            services.AddTransient<RpcClientFactory>();

            // return service collection to subscriber
            return services;
        }
    }
}
