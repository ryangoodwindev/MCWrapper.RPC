using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Ledger.Models.Control;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Control
{
    /// <summary>
    /// MutliChain methods implemented:
    /// 
    /// clearmempool, getblockchainparams, getinfo, getruntimeparams,
    /// help, pause, resume, setlastblock, setruntimeparam, stop
    /// </summary>
    public class ControlRpcClient : RpcConnection
    {
        /// <summary>
        /// Create a new Control RPC client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="options"></param>
        public ControlRpcClient(HttpClient client, IOptions<BlockchainRpcOptions> options) 
            : base(client, options) { }


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
        public async Task<RpcResponse<string>> ClearMemPoolAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, ControlAction.ClearMemPoolMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Removes all transactions from the TX memory pool.</para>
        /// <para>Local mining and the processing of incoming transactions and blocks should be paused.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<string>> ClearMemPoolAsync()
        {
            return ClearMemPoolAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


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
        public async Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(string blockchainName, string id, bool display_names = false, bool with_upgrades = false)
        {
            var response = await TransactAsync<RpcResponse<GetBlockchainParamsResult>>(blockchainName, ControlAction.GetBlockchainParamsMethod, id, display_names, with_upgrades);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns a list of values of this blockchain's parameters.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="display_names">Use display names instead of internal</param>
        /// <param name="with_upgrades">Take upgrades into account</param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(bool display_names = false, bool with_upgrades = false)
        {
            return GetBlockchainParamsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, display_names, with_upgrades);
        }


        /// <summary>
        /// 
        /// <para>Returns general information about this node and blockchain.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<GetInfoResult>> GetInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetInfoResult>>(blockchainName, ControlAction.GetInfoMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns general information about this node and blockchain.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetInfoResult>> GetInfoAsync()
        {
            return GetInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Returns a selection of this node's runtime parameters.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetRuntimeParamsResult>>(blockchainName, ControlAction.GetRuntimeParamsMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns a selection of this node's runtime parameters.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync()
        {
            return GetRuntimeParamsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


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
        public async Task<RpcResponse<object>> HelpAsync(string blockchainName, string id, string command = "")
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.HelpMethod, id, command);

            return response;
        }

        /// <summary>
        /// 
        /// <para>List all commands, or get help for a specified command.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="command">The command to get help with</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> HelpAsync(string command = "")
        {
            return HelpAsync(BlockchainOptions.ChainName, UUID.NoHyphens, command);
        }


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
        public async Task<RpcResponse<object>> PauseAsync(string blockchainName, string id, string tasks)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.PauseMethod, id, tasks);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Pauses local mining or the processing of incoming transactions and blocks.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="tasks">Task(s) to be paused. Possible values: incoming,mining,offchain</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> PauseAsync(string tasks)
        {
            return PauseAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tasks);
        }


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
        public async Task<RpcResponse<object>> ResumeAsync(string blockchainName, string id, string tasks)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.ResumeMethod, id, tasks);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Resumes local mining or the processing of incoming transactions and blocks</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tasks">Task(s) to be resumed. Possible values: incoming,mining,offchain</param>
        public Task<RpcResponse<object>> ResumeAsync(string tasks)
        {
            return ResumeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tasks);
        }


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
        public async Task<RpcResponse<object>> SetLastBlockAsync(string blockchainName, string id, [Optional] object hash_or_height)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.SetLastBlockMethod, id, hash_or_height);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Sets last block in the chain.</para>
        /// <para>Local mining and the processing of incoming transactions and blocks should be paused.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="hash_or_height">
        ///     <para>(string, optional) The block hash, if omitted - best chain is activated</para>
        ///     <para>or</para>
        ///     <para>(numeric, optional) The block height in active chain or height before current tip (if negative)</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SetLastBlockAsync([Optional] object hash_or_height)
        {
            return SetLastBlockAsync(BlockchainOptions.ChainName, UUID.NoHyphens, hash_or_height);
        }


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
        public async Task<RpcResponse<object>> SetRuntimeParamAsync(string blockchainName, string id, string runtimeParam, object parameter_value)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.SetRuntimeParamMethod, id, runtimeParam, parameter_value);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Sets value for runtime parameter</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="runtimeParam">Parameter name, one of the following: miningrequirespeers,mineemptyrounds,miningturnover,lockadminminerounds,maxshowndata,maxqueryscanitems,bantx,lockblock,autosubscribe,handshakelocal,hideknownopdrops</param>
        /// <param name="parameter_value">parameter value</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SetRuntimeParamAsync(string runtimeParam, object parameter_value)
        {
            return SetRuntimeParamAsync(BlockchainOptions.ChainName, UUID.NoHyphens, runtimeParam, parameter_value);
        }


        /// <summary>
        /// 
        /// <para>Shuts down the this blockchain node. Sends stop signal to MultiChain server.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<string>> StopAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, ControlAction.StopMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Shuts down the this blockchain node. Sends stop signal to MultiChain server.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<string>> StopAsync()
        {
            return StopAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }
    }
}