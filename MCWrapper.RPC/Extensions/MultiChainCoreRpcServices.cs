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

            // todo maybe we need to also check the Secret Manager for variable values?
            // todo perhap we can analyze cliOptions and/or runtimeOptions and if null'ish then we can verify Secret Manager

            // todo maybe we need some error handling here to detect lack of configuration early in the pipleline, as well. TBD

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
            services.AddHttpClient<IMultiChainRpcGeneral, MultiChainRpcGeneralClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcControl, MultiChainRpcControlClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcGenerate, MultiChainRpcGenerateClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcMining, MultiChainRpcMiningClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcNetwork, MultiChainRpcNetworkClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcOffChain, MultiChainRpcOffChainClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcRaw, MultiChainRpcRawClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcUtility, MultiChainRpcUtilityClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcWallet, MultiChainRpcWalletClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(rpcOptions);
               });

            // RpcClients and RpcClientFactory
            services.AddTransient<IMultiChainRpcClientFactory, MultiChainRpcClientFactory>();

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

            // todo change this, I don't like it. create your own service provider and pull from that
            RpcOptions _rpcOptions = new RpcOptions();

            // todo maybe we need some error handling here to detect lack of configuration early in the pipleline, as well. TBD

            // typed HttpClient configuration
            services.AddHttpClient<IMultiChainRpcGeneral, MultiChainRpcGeneralClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   // todo see line #163
                   _rpcOptions = sp.GetRequiredService<IOptions<RpcOptions>>().Value;
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcControl, MultiChainRpcControlClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcGenerate, MultiChainRpcGenerateClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcMining, MultiChainRpcMiningClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcNetwork, MultiChainRpcNetworkClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcOffChain, MultiChainRpcOffChainClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcRaw, MultiChainRpcRawClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcUtility, MultiChainRpcUtilityClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcWallet, MultiChainRpcWalletClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            // RpcClients and RpcClientFactory
            services.AddTransient<IMultiChainRpcClientFactory, MultiChainRpcClientFactory>();

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

            // todo change this, I don't like it. 
            // todo create your own service provider and pull from that
            RpcOptions _rpcOptions = new RpcOptions();

            // todo maybe we need some error handling here to detect lack of configuration early in the pipleline, as well. TBD

            // typed HttpClient configuration
            services.AddHttpClient<IMultiChainRpcGeneral, MultiChainRpcGeneralClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   // todo see line #267
                   _rpcOptions = sp.GetRequiredService<IOptions<RpcOptions>>().Value;
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcControl, MultiChainRpcControlClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcGenerate, MultiChainRpcGenerateClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcMining, MultiChainRpcMiningClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcNetwork, MultiChainRpcNetworkClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcOffChain, MultiChainRpcOffChainClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcRaw, MultiChainRpcRawClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcUtility, MultiChainRpcUtilityClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            services.AddHttpClient<IMultiChainRpcWallet, MultiChainRpcWalletClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
                   httpClient.BaseAddress = new Uri(ConnectionHelper.GetServiceUrl(_rpcOptions));
                   httpClient.DefaultRequestHeaders.Authorization = ConnectionHelper.GetAuthenticationHeaderValue(_rpcOptions);
               });

            // RpcClients and RpcClientFactory
            services.AddTransient<IMultiChainRpcClientFactory, MultiChainRpcClientFactory>();

            return services;
        }
    }
}