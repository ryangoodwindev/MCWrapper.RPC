using MCWrapper.Ledger.Entities.Extensions;
using MCWrapper.RPC.Extensions;

namespace MCWrapper.RPC.Options
{
    /// <summary>
    /// BlockchainRpcOptions values are mostly required for proper blockchain interaction to occur
    /// via the MCWrapper.RPC client.
    /// <para>
    ///     The MCWrapper RPC client requires the following BlockchainProfileOptions be assigned a valid value
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
        /// Create a new BlockchainRpcOptions object
        /// No arguments
        /// </summary>
        public RpcOptions() { }

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
        public string ChainName
        {
            get => !string.IsNullOrEmpty(_chainName) ? _chainName
                : nameof(ChainName).GetEnvironmentVariable() ?? string.Empty;

            set => _chainName = value;
        }
        private string _chainName = string.Empty;

        /// <summary>
        /// RPC port number as declared in the params.dat file or as override value in multichain.conf
        /// <para>
        ///     ChainRpcPort number is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public int? ChainRpcPort
        {
            get => _chainRpcPort != null ? _chainRpcPort
                : int.Parse(string.IsNullOrEmpty(nameof(ChainRpcPort).GetEnvironmentVariable()) ? "0"
                    : nameof(ChainRpcPort).GetEnvironmentVariable());

            set => _chainRpcPort = value;
        }
        private int? _chainRpcPort = null;

        /// <summary>
        /// Your blockchain node administror's public key. In v2 we are only supporting a 
        /// single node administrator per application instance.
        /// <para>
        ///     ChainAdminAddress is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainAdminAddress
        {
            get => !string.IsNullOrEmpty(_chainAdminAddress) ? _chainAdminAddress
                : nameof(ChainAdminAddress).GetEnvironmentVariable() ?? string.Empty;

            set => _chainAdminAddress = value;
        }
        private string _chainAdminAddress = string.Empty;

        /// <summary>
        /// IPv4 or FQDN of where the MultiChain network is hosted and/or accessible
        /// <para>
        ///     ChainHostname is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainHostname
        {
            get => !string.IsNullOrEmpty(_chainHostname) ? _chainHostname
                : nameof(ChainHostname).GetEnvironmentVariable() ?? string.Empty;

            set => _chainHostname = value;
        }
        private string _chainHostname = string.Empty;

        /// <summary>
        /// Blockchain address used for 'burning' Assets/Streams. 
        /// This is not a required property, however, it is nice to have the value available
        /// at the code level in case assets/streams do need to be burned.
        /// <para>
        ///     ChainBurnAddress is not required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainBurnAddress
        {
            get => !string.IsNullOrEmpty(_chainBurnAddress) ? _chainBurnAddress
                : nameof(ChainBurnAddress).GetEnvironmentVariable() ?? string.Empty;

            set => _chainBurnAddress = value;
        }
        private string _chainBurnAddress = string.Empty;

        /// <summary>
        /// RPCJSON username for target blockchain
        ///  <para>
        ///     ChainUsername is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainUsername
        {
            get => !string.IsNullOrEmpty(_chainUsername) ? _chainUsername
                : nameof(ChainUsername).GetEnvironmentVariable() ?? string.Empty;

            set => _chainUsername = value;
        }
        private string _chainUsername = string.Empty;

        /// <summary>
        /// RPCJSON password for target blockchain
        /// <para>
        ///     ChainPassword is required for the RPC client to function as expected;
        /// </para>
        /// </summary>
        public string ChainPassword
        {
            get => !string.IsNullOrEmpty(_chainPassword) ? _chainPassword
                : nameof(ChainPassword).GetEnvironmentVariable() ?? string.Empty;

            set => _chainPassword = value;
        }
        private string _chainPassword = string.Empty;

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
        public bool? ChainUseSsl
        {
            get => _chainUseSsl != null ? _chainUseSsl
                : bool.Parse(string.IsNullOrEmpty(nameof(ChainUseSsl).GetEnvironmentVariable()) ? "false"
                    : nameof(ChainUseSsl).GetEnvironmentVariable());

            set => _chainUseSsl = value;
        }
        private bool? _chainUseSsl = null;

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
        public string ChainSslPath
        {
            get => !string.IsNullOrEmpty(_chainSslPath) ? _chainSslPath
                : nameof(ChainSslPath).GetEnvironmentVariable() ?? string.Empty;

            set => _chainSslPath = value;
        }
        private string _chainSslPath = string.Empty;
    }
}
