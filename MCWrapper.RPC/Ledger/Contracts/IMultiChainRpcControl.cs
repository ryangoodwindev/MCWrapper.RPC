using MCWrapper.Data.Models.Control;
using MCWrapper.RPC.Connection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// 
    /// MutliChain methods required by the IBlockchainRpcControl contract:
    ///
    /// clearmempool, getblockchainparams, getinfo, getruntimeparams,
    /// help, pause, resume, setlastblock, setruntimeparam, stop
    /// 
    /// </summary>
    public interface IMultiChainRpcControl : IMultiChainRpc
    {
        /// <summary>
        ///
        /// <para>Removes all transactions from the TX memory pool.</para>
        /// <para>Local mining and the processing of incoming transactions and blocks should be paused.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<string>> ClearMemPoolAsync();

        /// <summary>
        ///
        /// <para>Removes all transactions from the TX memory pool.</para>
        /// <para>Local mining and the processing of incoming transactions and blocks should be paused.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<string>> ClearMemPoolAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns a list of values of this blockchain's parameters.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="display_names">Use display names instead of internal</param>
        /// <param name="with_upgrades">Take upgrades into account</param>
        /// <returns></returns>
        Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(bool display_names = false, bool with_upgrades = false);

        /// <summary>
        ///
        /// <para>Returns a list of values of this blockchain's parameters.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="display_names">Use display names instead of internal</param>
        /// <param name="with_upgrades">Take upgrades into account</param>
        /// <returns></returns>
        Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(string blockchainName, string id, bool display_names = false, bool with_upgrades = false);

        /// <summary>
        ///
        /// <para>Returns general information about this node and blockchain.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<GetInfoResult>> GetInfoAsync();

        /// <summary>
        ///
        /// <para>Returns general information about this node and blockchain.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<GetInfoResult>> GetInfoAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns a selection of this node's runtime parameters.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync();

        /// <summary>
        ///
        /// <para>Returns a selection of this node's runtime parameters.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>List all commands, or get help for a specified command.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="command">The command to get help with</param>
        /// <returns></returns>
        Task<RpcResponse<object>> HelpAsync(string command = "getinfo");

        /// <summary>
        ///
        /// <para>List all commands, or get help for a specified command.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="command">The command to get help with</param>
        /// <returns></returns>
        Task<RpcResponse<object>> HelpAsync(string blockchainName, string id, string command = "getinfo");

        /// <summary>
        ///
        /// <para>Pauses local mining or the processing of incoming transactions and blocks.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tasks">Task(s) to be paused. Possible values: incoming,mining,offchain</param>
        /// <returns></returns>
        Task<RpcResponse<object>> PauseAsync(string tasks = "incoming,mining");

        /// <summary>
        ///
        /// <para>Pauses local mining or the processing of incoming transactions and blocks.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tasks">Task(s) to be paused. Possible values: incoming,mining,offchain</param>
        /// <returns></returns>
        Task<RpcResponse<object>> PauseAsync(string blockchainName, string id, string tasks = "incoming,mining");

        /// <summary>
        ///
        /// <para>Resumes local mining or the processing of incoming transactions and blocks</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tasks">Task(s) to be resumed. Possible values: incoming,mining,offchain</param>
        Task<RpcResponse<object>> ResumeAsync(string tasks = "incoming,mining");

        /// <summary>
        ///
        /// <para>Resumes local mining or the processing of incoming transactions and blocks</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tasks">Task(s) to be resumed. Possible values: incoming,mining,offchain</param>
        /// <returns></returns>
        Task<RpcResponse<object>> ResumeAsync(string blockchainName, string id, string tasks = "incoming,mining");

        /// <summary>
        ///
        /// <para>Sets last block in the chain.</para>
        /// <para>Local mining and the processing of incoming transactions and blocks should be paused.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="hash_or_height">
        ///     <para>(string, optional) The block hash, if omitted - best chain is activated</para>
        ///     <para>or</para>
        ///     <para>(numeric, optional) The block height in active chain or height before current tip (if negative)</para>
        /// </param>
        /// <returns></returns>
        Task<RpcResponse<object>> SetLastBlockAsync([Optional] object hash_or_height);

        /// <summary>
        ///
        /// <para>Sets last block in the chain.</para>
        /// <para>Local mining and the processing of incoming transactions and blocks should be paused.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="hash_or_height">
        ///     <para>(string, optional) The block hash, if omitted - best chain is activated</para>
        ///     <para>or</para>
        ///     <para>(numeric, optional) The block height in active chain or height before current tip (if negative)</para>
        /// </param>
        /// <returns></returns>
        Task<RpcResponse<object>> SetLastBlockAsync(string blockchainName, string id, [Optional] object hash_or_height);

        /// <summary>
        ///
        /// <para>Sets value for runtime parameter</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="runtimeParam">Parameter name, one of the following: miningrequirespeers,mineemptyrounds,miningturnover,lockadminminerounds,maxshowndata,maxqueryscanitems,bantx,lockblock,autosubscribe,handshakelocal,hideknownopdrops</param>
        /// <param name="parameter_value">parameter value</param>
        /// <returns></returns>
        Task<RpcResponse<object>> SetRuntimeParamAsync(string runtimeParam, object parameter_value);

        /// <summary>
        ///
        /// <para>Sets value for runtime parameter</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="runtimeParam">Parameter name, one of the following: miningrequirespeers,mineemptyrounds,miningturnover,lockadminminerounds,maxshowndata,maxqueryscanitems,bantx,lockblock,autosubscribe,handshakelocal,hideknownopdrops</param>
        /// <param name="parameter_value">parameter value</param>
        /// <returns></returns>
        Task<RpcResponse<object>> SetRuntimeParamAsync(string blockchainName, string id, string runtimeParam, object parameter_value);

        /// <summary>
        ///
        /// <para>Shuts down the this blockchain node. Sends stop signal to MultiChain server.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<string>> StopAsync();

        /// <summary>
        ///
        /// <para>Shuts down the this blockchain node. Sends stop signal to MultiChain server.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<string>> StopAsync(string blockchainName, string id);
    }
}