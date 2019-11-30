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
    /// <summary>
    /// Extension methods offering several different options for adding MultiChain Core JSON-RPC services to your .NET Core application.
    /// </summary>
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
        ///     This method automatically loads the RpcOptions and RuntimeParamOptions from the
        ///     local environment variable store.
        /// </para>
        ///  <para>
        ///     RpcOptions environment variable names:
        ///     ChainAdminAddress,
        ///     ChainBurnAddress,
        ///     ChainHostname,
        ///     ChainPassword,
        ///     ChainUsername,
        ///     ChainName,
        ///     ChainRpcPort,
        ///     ChainUseSsl
        /// </para>
        /// </summary>
        /// <param name="services">Service container</param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreRpcServices(this IServiceCollection services)
        {
            var rpcOptions = new RpcOptions(true);
            var runtimeOptions = new RuntimeParamOptions(true);

            // detect misconfiguration early in the pipeline
            if (string.IsNullOrEmpty(rpcOptions.ChainAdminAddress)) throw new ArgumentNullException($"{nameof(rpcOptions.ChainAdminAddress)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(rpcOptions.ChainBurnAddress)) throw new ArgumentNullException($"{nameof(rpcOptions.ChainBurnAddress)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(rpcOptions.ChainHostname)) throw new ArgumentNullException($"{nameof(rpcOptions.ChainHostname)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(rpcOptions.ChainPassword)) throw new ArgumentNullException($"{nameof(rpcOptions.ChainPassword)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(rpcOptions.ChainUsername)) throw new ArgumentNullException($"{nameof(rpcOptions.ChainUsername)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(rpcOptions.ChainName)) throw new ArgumentNullException($"{nameof(rpcOptions.ChainName)} is required and cannot be empty or null");
            if (rpcOptions.ChainRpcPort == null) throw new ArgumentNullException($"{nameof(rpcOptions.ChainRpcPort)} is required and cannot be null");
            if (rpcOptions.ChainUseSsl == null) throw new ArgumentNullException($"{nameof(rpcOptions.ChainUseSsl)} is required and cannot be null");

            // load Options from the local environment variable store
            services.Configure<RpcOptions>(config =>
            {
                config.ChainAdminAddress = rpcOptions.ChainAdminAddress;
                config.ChainBurnAddress = rpcOptions.ChainBurnAddress;
                config.ChainHostname = rpcOptions.ChainHostname;
                config.ChainPassword = rpcOptions.ChainPassword;
                config.ChainUsername = rpcOptions.ChainUsername;
                config.ChainRpcPort = rpcOptions.ChainRpcPort;
                config.ChainUseSsl = rpcOptions.ChainUseSsl;
                config.ChainName = rpcOptions.ChainName;
            })
                .Configure<RuntimeParamOptions>(config =>
                {
                    config.MiningRequiresPeers = runtimeOptions.MiningRequiresPeers;
                    config.LockAdminMineRounds = runtimeOptions.LockAdminMineRounds;
                    config.MaxQueryScanItems = runtimeOptions.MaxQueryScanItems;
                    config.HideKnownOpDrops = runtimeOptions.HideKnownOpDrops;
                    config.MineEmptyRounds = runtimeOptions.MineEmptyRounds;
                    config.HandshakeLocal = runtimeOptions.HandshakeLocal;
                    config.MiningTurnOver = runtimeOptions.MiningTurnOver;
                    config.AutoSubscribe = runtimeOptions.AutoSubscribe;
                    config.MaxShownData = runtimeOptions.MaxShownData;
                    config.LockBlock = runtimeOptions.LockBlock;
                    config.BanTx = runtimeOptions.BanTx;
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
        ///     This method automatically loads the RpcOptions and RuntimeParamOptions from the
        ///     IConfiguration interface (appsettings.json file usually). If no values are found
        ///     to be present on the configuration file the Secrets Manager store is verified next.
        /// </para>
        /// 
        /// <para>
        ///     RpcOptions appsettings.json variable names:
        ///     ChainAdminAddress,
        ///     ChainBurnAddress,
        ///     ChainHostname,
        ///     ChainPassword,
        ///     ChainUsername,
        ///     ChainName,
        ///     ChainRpcPort,
        ///     ChainUseSsl
        /// </para>
        /// 
        /// <para>
        ///     RpcOptions Secrets Manager variable names:
        ///     MULTICHAIN:ADMINADDRESS,
        ///     MULTICHAIN:BURNADDRESS,
        ///     MULTICHAIN:HOSTNAME,
        ///     MULTICHAIN:PASSWORD,
        ///     MULTICHAIN:USERNAME,
        ///     MULTICHAIN:NAME,
        ///     MULTICHAIN:RPCPORT,
        ///     MULTICHAIN:USESSL
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

            var provider = services.BuildServiceProvider();
            RpcOptions _rpcOptions = provider.GetRequiredService<IOptions<RpcOptions>>().Value;

            // detect misconfiguration early in the pipeline
            _rpcOptions.ChainAdminAddress = !string.IsNullOrEmpty(_rpcOptions.ChainAdminAddress) ? _rpcOptions.ChainAdminAddress 
                : !string.IsNullOrEmpty(configuration["MULTICHAIN__ADMINADDRESS"]) ? configuration["MULTICHAIN__ADMINADDRESS"] 
                : throw new ArgumentNullException($"{nameof(_rpcOptions.ChainAdminAddress)} is required and cannot be empty or null");

            _rpcOptions.ChainBurnAddress = !string.IsNullOrEmpty(_rpcOptions.ChainBurnAddress) ? _rpcOptions.ChainBurnAddress
                : !string.IsNullOrEmpty(configuration["MULTICHAIN__BURNADDRESS"]) ? configuration["MULTICHAIN_BURNADDRESS"] 
                :throw new ArgumentNullException($"{nameof(_rpcOptions.ChainBurnAddress)} is required and cannot be empty or null");

            _rpcOptions.ChainHostname = !string.IsNullOrEmpty(_rpcOptions.ChainHostname) ? _rpcOptions.ChainHostname
                : !string.IsNullOrEmpty(configuration["MULTICHAIN__HOSTNAME"]) ? configuration["MULTICHAIN__HOSTNAME"]
                : throw new ArgumentNullException($"{nameof(_rpcOptions.ChainHostname)} is required and cannot be empty or null");

            _rpcOptions.ChainPassword = !string.IsNullOrEmpty(_rpcOptions.ChainPassword) ? _rpcOptions.ChainPassword
                : !string.IsNullOrEmpty(configuration["MULTICHAIN__PASSWORD"]) ? configuration["MULTICHAIN__PASSWORD"]
                : throw new ArgumentNullException($"{nameof(_rpcOptions.ChainPassword)} is required and cannot be empty or null");

            _rpcOptions.ChainUsername = !string.IsNullOrEmpty(_rpcOptions.ChainUsername) ? _rpcOptions.ChainUsername
                : !string.IsNullOrEmpty(configuration["MULTICHAIN__USERNAME"]) ? configuration["MULTICHAIN__USERNAME"]
                : throw new ArgumentNullException($"{nameof(_rpcOptions.ChainUsername)} is required and cannot be empty or null");

            _rpcOptions.ChainName = !string.IsNullOrEmpty(_rpcOptions.ChainName) ? _rpcOptions.ChainName
                : !string.IsNullOrEmpty(configuration["MULTICHAIN__NAME"]) ? configuration["MULTICHAIN__NAME"]
                : throw new ArgumentNullException($"{nameof(_rpcOptions.ChainName)} is required and cannot be empty or null");

            _rpcOptions.ChainRpcPort = _rpcOptions.ChainRpcPort != null ? _rpcOptions.ChainRpcPort
                : !string.IsNullOrEmpty(configuration["MULTICHAIN__RPCPORT"]) ? int.Parse(configuration["MULTICHAIN__RPCPORT"])
                : throw new ArgumentNullException($"{nameof(_rpcOptions.ChainRpcPort)} is required and cannot be null");

            _rpcOptions.ChainUseSsl = _rpcOptions.ChainUseSsl != null ? _rpcOptions.ChainUseSsl
                : !string.IsNullOrEmpty(configuration["MULTICHAIN__USESSL"]) ? bool.Parse(configuration["MULTICHAIN__USESSL"])
                : throw new ArgumentNullException($"{nameof(_rpcOptions.ChainUseSsl)} is required and cannot be null");

            // typed HttpClient configuration
            services.AddHttpClient<IMultiChainRpcGeneral, MultiChainRpcGeneralClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
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
        ///     This method requires the RpcOptions and RuntimeParamOptions property values to be
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
            var _rpcOptions = new RpcOptions();
            rpcOptions?.Invoke(_rpcOptions);

            // detect misconfiguration early in the pipeline
            if (string.IsNullOrEmpty(_rpcOptions.ChainAdminAddress)) throw new ArgumentNullException($"{nameof(_rpcOptions.ChainAdminAddress)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(_rpcOptions.ChainBurnAddress)) throw new ArgumentNullException($"{nameof(_rpcOptions.ChainBurnAddress)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(_rpcOptions.ChainHostname)) throw new ArgumentNullException($"{nameof(_rpcOptions.ChainHostname)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(_rpcOptions.ChainPassword)) throw new ArgumentNullException($"{nameof(_rpcOptions.ChainPassword)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(_rpcOptions.ChainUsername)) throw new ArgumentNullException($"{nameof(_rpcOptions.ChainUsername)} is required and cannot be empty or null");
            if (string.IsNullOrEmpty(_rpcOptions.ChainName)) throw new ArgumentNullException($"{nameof(_rpcOptions.ChainName)} is required and cannot be empty or null");
            if (_rpcOptions.ChainRpcPort == null) throw new ArgumentNullException($"{nameof(_rpcOptions.ChainRpcPort)} is required and cannot be null");
            if (_rpcOptions.ChainUseSsl == null) throw new ArgumentNullException($"{nameof(_rpcOptions.ChainUseSsl)} is required and cannot be null");

            // configure Options
            services.Configure<RpcOptions>(config =>
            {
                config.ChainAdminAddress = _rpcOptions.ChainAdminAddress;
                config.ChainBurnAddress = _rpcOptions.ChainBurnAddress;
                config.ChainHostname = _rpcOptions.ChainHostname;
                config.ChainPassword = _rpcOptions.ChainPassword;
                config.ChainUsername = _rpcOptions.ChainUsername;
                config.ChainRpcPort = _rpcOptions.ChainRpcPort;
                config.ChainUseSsl = _rpcOptions.ChainUseSsl;
                config.ChainName = _rpcOptions.ChainName;
            });
                
            if (runtimeParamOptions != null)
            {
                var _runtimeParamOptions = new RuntimeParamOptions();
                runtimeParamOptions?.Invoke(_runtimeParamOptions);

                services.Configure<RuntimeParamOptions>(config =>
                {
                    config.MiningRequiresPeers = _runtimeParamOptions.MiningRequiresPeers;
                    config.LockAdminMineRounds = _runtimeParamOptions.LockAdminMineRounds;
                    config.MaxQueryScanItems = _runtimeParamOptions.MaxQueryScanItems;
                    config.HideKnownOpDrops = _runtimeParamOptions.HideKnownOpDrops;
                    config.MineEmptyRounds = _runtimeParamOptions.MineEmptyRounds;
                    config.MiningTurnOver = _runtimeParamOptions.MiningTurnOver;
                    config.HandshakeLocal = _runtimeParamOptions.HandshakeLocal;
                    config.AutoSubscribe = _runtimeParamOptions.AutoSubscribe;
                    config.MaxShownData = _runtimeParamOptions.MaxShownData;
                    config.LockBlock = _runtimeParamOptions.LockBlock;
                    config.BanTx = _runtimeParamOptions.BanTx;
                });
            }

            // typed HttpClient configuration
            services.AddHttpClient<IMultiChainRpcGeneral, MultiChainRpcGeneralClient>()
               .ConfigureHttpClient((sp, httpClient) =>
               {
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

            // IMultiChainRpcClientFactory serves up instances of IMultiChainRpc
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
        ///     This method requires the RpcOptions and RuntimeParamOptions property values to be
        ///     explicitly passed via the individual parameters for this method and the optional,
        ///     <paramref name="runtimeParamOptions"/> Action parameter when added to the DI pipeline.
        /// </para>
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="chainName">MultiChain Core blockchain node name</param>
        /// <param name="useSsl">true = HTTPS / false = HTTP</param>
        /// <param name="rpcPort">MultiChain Core blockchain JSON-RPC port number</param>
        /// <param name="hostname">MultiChain Core blockchain hostname, usually 'localhost', 127.0.0.1, 0.0.0.0, or FQDN</param>
        /// <param name="password">MultiChain Core blockchain possword located in the multichain.conf file</param>
        /// <param name="username">MultiChain Core blockchain username located in the multichain.conf file</param>
        /// <param name="burnAddress">MultiChain Core blockchain Burn address</param>
        /// <param name="adminAddress">MultiChain Core blockchain Admin address</param>
        /// <param name="runtimeParamOptions">Optional configuration of MultiChain Core runtime parameters</param>
        /// <returns></returns>
        public static IServiceCollection AddMultiChainCoreRpcServices(this IServiceCollection services, string chainName, bool useSsl, int rpcPort, string hostname, string password, string username, string burnAddress, string adminAddress, [Optional] Action<RuntimeParamOptions> runtimeParamOptions)
        {
            var rpcOptions = new RpcOptions(adminAddress, burnAddress, hostname, password, username, rpcPort, chainName, useSsl);

            // configure Options
            services.Configure<RpcOptions>(config =>
            {
                config.ChainAdminAddress = rpcOptions.ChainAdminAddress;
                config.ChainBurnAddress = rpcOptions.ChainBurnAddress;
                config.ChainHostname = rpcOptions.ChainHostname;
                config.ChainPassword = rpcOptions.ChainPassword;
                config.ChainUsername = rpcOptions.ChainUsername;
                config.ChainRpcPort = rpcOptions.ChainRpcPort;
                config.ChainUseSsl = rpcOptions.ChainUseSsl;
                config.ChainName = rpcOptions.ChainName;
            });

            if (runtimeParamOptions != null)
            {
                var _runtimeParamOptions = new RuntimeParamOptions();
                runtimeParamOptions?.Invoke(_runtimeParamOptions);

                services.Configure<RuntimeParamOptions>(config =>
                {
                    config.MiningRequiresPeers = _runtimeParamOptions.MiningRequiresPeers;
                    config.LockAdminMineRounds = _runtimeParamOptions.LockAdminMineRounds;
                    config.MaxQueryScanItems = _runtimeParamOptions.MaxQueryScanItems;
                    config.HideKnownOpDrops = _runtimeParamOptions.HideKnownOpDrops;
                    config.MineEmptyRounds = _runtimeParamOptions.MineEmptyRounds;
                    config.MiningTurnOver = _runtimeParamOptions.MiningTurnOver;
                    config.HandshakeLocal = _runtimeParamOptions.HandshakeLocal;
                    config.AutoSubscribe = _runtimeParamOptions.AutoSubscribe;
                    config.MaxShownData = _runtimeParamOptions.MaxShownData;
                    config.LockBlock = _runtimeParamOptions.LockBlock;
                    config.BanTx = _runtimeParamOptions.BanTx;
                });
            }

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

            // IMultiChainRpcClientFactory serves up instances of IMultiChainRpc
            services.AddTransient<IMultiChainRpcClientFactory, MultiChainRpcClientFactory>();

            return services;
        }
    }
}