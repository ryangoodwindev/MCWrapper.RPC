using MCWrapper.Data.Models.Control;
using MCWrapper.Ledger.Actions;
using MCWrapper.Ledger.Entities.Extensions;
using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// 
    /// <para>MutliChain Core methods implemented by the MultiChainRpcControlClient concrete class</para>
    ///
    /// clearmempool, getblockchainparams, getinfo, getruntimeparams,
    /// help, pause, resume, setlastblock, setruntimeparam, stop
    /// 
    /// </summary>
    public class MultiChainRpcControlClient : MultiChainRpcClient, IMultiChainRpcControl
    {
        /// <summary>
        /// Create a new MultiChainRpcControlClient instance
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public MultiChainRpcControlClient(HttpClient httpClient, IOptions<RpcOptions> options)
            : base(httpClient, options) { }

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
        public Task<RpcResponse<string>> ClearMemPoolAsync(string blockchainName, string id) =>
            TransactAsync<string>(blockchainName, ControlAction.ClearMemPoolMethod, id);

        /// <summary>
        ///
        /// <para>Removes all transactions from the TX memory pool.</para>
        /// <para>Local mining and the processing of incoming transactions and blocks should be paused.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<string>> ClearMemPoolAsync() =>
            ClearMemPoolAsync(RpcOptions.ChainName, UUID.NoHyphens);

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
        public Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(string blockchainName, string id, bool display_names = false, bool with_upgrades = false) =>
            TransactAsync<GetBlockchainParamsResult>(blockchainName, ControlAction.GetBlockchainParamsMethod, id, display_names, with_upgrades);

        /// <summary>
        ///
        /// <para>Returns a list of values of this blockchain's parameters.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="display_names">Use display names instead of internal</param>
        /// <param name="with_upgrades">Take upgrades into account</param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(bool display_names = false, bool with_upgrades = false) =>
            GetBlockchainParamsAsync(RpcOptions.ChainName, UUID.NoHyphens, display_names, with_upgrades);

        /// <summary>
        ///
        /// <para>Returns general information about this node and blockchain.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetInfoResult>> GetInfoAsync(string blockchainName, string id) =>
            TransactAsync<GetInfoResult>(blockchainName, ControlAction.GetInfoMethod, id);

        /// <summary>
        ///
        /// <para>Returns general information about this node and blockchain.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetInfoResult>> GetInfoAsync() =>
            GetInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        /// Returns information about initialization status of this node
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetInitStatusResult>> GetInitStatusAsync(string blockchainName, string id) =>
            TransactAsync<GetInitStatusResult>(blockchainName, ControlAction.GetInitStatus, id);

        /// <summary>
        /// Returns information about initialization status of this node
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetInitStatusResult>> GetInitStatusAsync() =>
            GetInitStatusAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// <para>Returns a selection of this node's runtime parameters.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync(string blockchainName, string id) =>
            TransactAsync<GetRuntimeParamsResult>(blockchainName, ControlAction.GetRuntimeParamsMethod, id);

        /// <summary>
        ///
        /// <para>Returns a selection of this node's runtime parameters.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync() =>
            GetRuntimeParamsAsync(RpcOptions.ChainName, UUID.NoHyphens);

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
        public Task<RpcResponse<string>> HelpAsync(string blockchainName, string id, string command = "getinfo") =>
            TransactAsync<string>(blockchainName, ControlAction.HelpMethod, id, command);

        /// <summary>
        ///
        /// <para>List all commands, or get help for a specified command.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="command">The command to get help with</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> HelpAsync(string command = "getinfo") =>
            HelpAsync(RpcOptions.ChainName, UUID.NoHyphens, command);

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
        public Task<RpcResponse<object>> PauseAsync(string blockchainName, string id, string tasks = "incoming,mining") =>
            TransactAsync<object>(blockchainName, ControlAction.PauseMethod, id, tasks);

        /// <summary>
        ///
        /// <para>Pauses local mining or the processing of incoming transactions and blocks.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tasks">Task(s) to be paused. Possible values: incoming,mining,offchain</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> PauseAsync(string tasks = "incoming,mining") =>
            PauseAsync(RpcOptions.ChainName, UUID.NoHyphens, tasks);

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
        public Task<RpcResponse<object>> ResumeAsync(string blockchainName, string id, string tasks = "incoming,mining") =>
            TransactAsync<object>(blockchainName, ControlAction.ResumeMethod, id, tasks);

        /// <summary>
        ///
        /// <para>Resumes local mining or the processing of incoming transactions and blocks</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tasks">Task(s) to be resumed. Possible values: incoming,mining,offchain</param>
        public Task<RpcResponse<object>> ResumeAsync(string tasks = "incoming,mining") =>
            ResumeAsync(RpcOptions.ChainName, UUID.NoHyphens, tasks);

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
        public Task<RpcResponse<string>> SetLastBlockAsync(string blockchainName, string id, [Optional] object hash_or_height) =>
            TransactAsync<string>(blockchainName, ControlAction.SetLastBlockMethod, id, hash_or_height);

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
        public Task<RpcResponse<string>> SetLastBlockAsync([Optional] object hash_or_height) =>
            SetLastBlockAsync(RpcOptions.ChainName, UUID.NoHyphens, hash_or_height);

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
        public Task<RpcResponse<object>> SetRuntimeParamAsync(string blockchainName, string id, string runtimeParam, object parameter_value) =>
            TransactAsync<object>(blockchainName, ControlAction.SetRuntimeParamMethod, id, runtimeParam, parameter_value);

        /// <summary>
        ///
        /// <para>Sets value for runtime parameter</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="runtimeParam">Parameter name, one of the following: miningrequirespeers,mineemptyrounds,miningturnover,lockadminminerounds,maxshowndata,maxqueryscanitems,bantx,lockblock,autosubscribe,handshakelocal,hideknownopdrops</param>
        /// <param name="parameter_value">parameter value</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SetRuntimeParamAsync(string runtimeParam, object parameter_value) =>
            SetRuntimeParamAsync(RpcOptions.ChainName, UUID.NoHyphens, runtimeParam, parameter_value);

        /// <summary>
        ///
        /// <para>Shuts down the this blockchain node. Sends stop signal to MultiChain server.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> StopAsync(string blockchainName, string id) =>
            TransactAsync<string>(blockchainName, ControlAction.StopMethod, id);

        /// <summary>
        ///
        /// <para>Shuts down the this blockchain node. Sends stop signal to MultiChain server.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<string>> StopAsync() =>
            StopAsync(RpcOptions.ChainName, UUID.NoHyphens);
    }
}