using MCWrapper.Ledger.Entities.Options;
using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Ledger.Clients;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
        /// <param name="services">Service container</param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreRpcServices(this IServiceCollection services)
        {
            var rpcOptions = new RpcOptions(true);
            var runtimeOptions = new RuntimeParamOptions(true);

            // load Options from the local environment variable store
            services.Configure<RuntimeParamOptions>(config => 
            {
                config.BanTx = runtimeOptions.BanTx;
                config.LockBlock = runtimeOptions.LockBlock;
                config.MaxShownData = runtimeOptions.MaxShownData;
                config.AutoSubscribe = runtimeOptions.AutoSubscribe;
                config.HandshakeLocal = runtimeOptions.HandshakeLocal;
                config.MiningTurnOver = runtimeOptions.MiningTurnOver;
                config.MineEmptyRounds = runtimeOptions.MineEmptyRounds;
                config.HideKnownOpDrops = runtimeOptions.HideKnownOpDrops;
                config.MaxQueryScanItems = runtimeOptions.MaxQueryScanItems;
                config.LockAdminMineRounds = runtimeOptions.LockAdminMineRounds;
                config.MiningRequiresPeers = runtimeOptions.MiningRequiresPeers;
            })
            .Configure<RpcOptions>(config => 
            {
                config.ChainName = rpcOptions.ChainName;
                config.ChainUseSsl = rpcOptions.ChainUseSsl;
                config.ChainRpcPort = rpcOptions.ChainRpcPort;
                config.ChainSslPath = rpcOptions.ChainSslPath;
                config.ChainHostname = rpcOptions.ChainHostname;
                config.ChainPassword = rpcOptions.ChainPassword;
                config.ChainUsername = rpcOptions.ChainUsername;
                config.ChainBurnAddress = rpcOptions.ChainBurnAddress;
                config.ChainAdminAddress = rpcOptions.ChainAdminAddress;
            });

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
        /// <param name="services">Service container</param>
        /// <param name="configuration">Configuration pipeline</param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreRpcServices(this IServiceCollection services, IConfiguration configuration)
        {
            // load Options from the IConfiguration interface (appsettings.json file usually)
            services.Configure<RuntimeParamOptions>(configuration)
                .Configure<RpcOptions>(configuration);

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
        ///     explicitly passed via the <paramref name="runtimeParamOptions"/> and <paramref name="rpcOptions"/> 
        ///     Action parameters when added to the DI pipeline.
        /// </para>
        /// </summary>
        /// <param name="services">Service container</param>
        /// <param name="rpcOptions">Blockchain profile configuration (Information the app will use to connect to a MultiChain ledger)</param>
        /// <param name="runtimeParamOptions">Runtime parameter configuration (How a MultiChain ledger should behave)</param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreRpcServices(this IServiceCollection services, Action<RpcOptions> rpcOptions, [Optional] Action<RuntimeParamOptions> runtimeParamOptions)
        {
            // configure Options
            services.Configure((Action<RuntimeParamOptions>)(config => runtimeParamOptions?.Invoke(new RuntimeParamOptions())))
                .Configure((Action<RpcOptions>)(config => rpcOptions?.Invoke(new RpcOptions())));

            var profile = services.BuildServiceProvider()
                .GetService<IOptions<RpcOptions>>().Value;

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