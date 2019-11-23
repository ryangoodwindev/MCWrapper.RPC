using MCWrapper.Ledger.Entities.Extensions;

namespace MCWrapper.RPC.Options
{
    /// <summary>
    /// RpcOptions values are mostly required for proper blockchain interaction to occur
    /// via the MCWrapper.RPC client.
    /// <para>
    ///     The MCWrapper RPC client requires the following RpcOptions be assigned a valid value
    ///         ChainUseSsl;
    ///         ChainSslPath 
    ///             (ChainSslPath only required to be assigned a file path value if ChainUseSsl is true, 
    ///              otherwise ChainSslPath can be empty string "");
    ///         ChainUsername;
    ///         ChainPassword;
    ///         ChainName;
    ///         ChainRpcPort;
    ///         ChainAdminAddress;
    ///         ChainHostname;
    /// </para>
    /// </summary>
    public class RpcOptions
    {
        /// <summary>
        /// Create a new RpcOptions object
        /// No arguments
        /// </summary>
        public RpcOptions() { }

        /// <summary>
        /// Create a new RpcOptions object
        /// No arguments
        /// </summary>
        public RpcOptions(bool loadFromEnvironment)
        {
            if (loadFromEnvironment)
            {
                ChainName = nameof(ChainName).GetEnvironmentVariable();
                int.TryParse(nameof(ChainRpcPort).GetEnvironmentVariable(), out int outChainRpcPort);
                ChainRpcPort = outChainRpcPort;
                ChainAdminAddress = nameof(ChainAdminAddress).GetEnvironmentVariable();
                ChainHostname = nameof(ChainHostname).GetEnvironmentVariable();
                ChainBurnAddress = nameof(ChainBurnAddress).GetEnvironmentVariable();
                ChainUsername = nameof(ChainUsername).GetEnvironmentVariable();
                ChainPassword = nameof(ChainPassword).GetEnvironmentVariable();
                bool.TryParse(nameof(ChainUseSsl).GetEnvironmentVariable(), out bool outChainUseSsl);
                ChainUseSsl = outChainUseSsl;
                ChainSslPath = nameof(ChainSslPath).GetEnvironmentVariable();
            }
        }

        /// <summary>
        /// Multichain blockchain name as declared in the params.dat file;
        /// 
        /// <para>
        ///     ChainName value is required for the RPC client to 
        ///     function as expected when using methods that infer
        ///     the blockchain name value;
        /// </para>
        /// 
        /// <para>
        ///     When using methods that support using the blockchain
        ///     name explicitly with the RPC client,the 
        ///     ChainName value is not necessary or required.
        /// </para>
        /// 
        /// </summary>
        public string ChainName { get; set; } = string.Empty;

        /// <summary>
        /// RPC port number as declared in the params.dat file or as override value in multichain.conf
        /// <para>
        ///     ChainRpcPort number is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public int? ChainRpcPort { get; set; } = null;

        /// <summary>
        /// Your blockchain node administror's public key. In v2 we are only supporting a 
        /// single node administrator per application instance.
        /// <para>
        ///     ChainAdminAddress is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainAdminAddress { get; set; } = string.Empty;

        /// <summary>
        /// IPv4 or FQDN of where the MultiChain network is hosted and/or accessible
        /// <para>
        ///     ChainHostname is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainHostname { get; set; } = string.Empty;

        /// <summary>
        /// Blockchain address used for 'burning' Assets/Streams. 
        /// This is not a required property, however, it is nice to have the value available
        /// at the code level in case assets/streams do need to be burned.
        /// <para>
        ///     ChainBurnAddress is not required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainBurnAddress { get; set; } = string.Empty;

        /// <summary>
        /// RPCJSON username for target blockchain
        ///  <para>
        ///     ChainUsername is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainUsername { get; set; } = string.Empty;

        /// <summary>
        /// RPCJSON password for target blockchain
        /// <para>
        ///     ChainPassword is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainPassword { get; set; } = string.Empty;

        /// <summary>
        /// SSL Flag
        /// <para>
        ///     ChainUseSsl is not required for the RPC client to function as expected;
        ///     However, if you wish to transact with the node using HTTPS this value must
        ///     be and equal true
        /// </para>
        /// <para>
        ///     Please note: If the ChainUseSsl value is true, the ChainSslPath value
        ///     MUST be populated and accurate. When starting an HTTPS blockahin ensure
        ///     you pass the -rpcssl flag and properly configure your multichain.conf file
        ///     properly to support HTTPS connection.
        /// </para>
        /// </summary>
        public bool? ChainUseSsl { get; set; } = null;

        /// <summary>
        /// Local or remote file path to a copy of the same SSL certificate that is securing
        /// the current node the application is interacting with.
        /// <para>
        ///     ChainSslPath is not required for the RPC client to function as expected;
        /// </para>
        /// <para>
        ///     Please note: If the ChainUseSsl value is true, the ChainSslPath value
        ///     MUST be populated and accurate. When starting an HTTPS blockahin ensure
        ///     you pass the -rpcssl flag and properly configure your multichain.conf file
        ///     properly to support HTTPS connections.
        /// </para>
        /// </summary>
        public string ChainSslPath { get; set; } = string.Empty;
    }
}
