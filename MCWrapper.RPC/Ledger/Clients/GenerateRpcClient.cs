﻿using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Generate
{
    /// <summary>
    /// MutliChain methods implemented:
    /// 
    /// getgenerate, gethashespersec, setgenerate
    /// </summary>
    public class GenerateRpcClient : RpcConnection
    {
        /// <summary>
        /// Create a new Generate RPC client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="options"></param>
        public GenerateRpcClient(HttpClient client, IOptions<BlockchainRpcOptions> options) 
            : base(client, options) { }


        /// <summary>
        /// <para>Return if the server is set to generate coins or not. The default is false.</para>
        /// <para>It is set with the command line argument -gen (or bitcoin.conf setting gen)</para>
        /// <para>It can also be set with the setgenerate call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns>If the server is set to generate coins or not</returns>
        public async Task<RpcResponse<bool>> GetGenerateAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<bool>>(blockchainName, GenerateAction.GetGenerateMethod, id);

            return response;
        }

        /// <summary>
        /// <para>Return if the server is set to generate coins or not. The default is false.</para>
        /// <para>It is set with the command line argument -gen (or bitcoin.conf setting gen)</para>
        /// <para>It can also be set with the setgenerate call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns>If the server is set to generate coins or not</returns>
        public Task<RpcResponse<bool>> GetGenerateAsync()
        {
            return GetGenerateAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// <para>Returns a recent hashes per second performance measurement while generating.</para>
        /// <para>See the getgenerate and setgenerate calls to turn generation on and off.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns>(numeric) The recent hashes per second when generation is on (will return 0 if generation is off)</returns>
        public async Task<RpcResponse<int>> GetHashesPerSecAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<int>>(blockchainName, GenerateAction.GetHashesPerSecMethod, id);

            return response;
        }

        /// <summary>
        /// <para>Returns a recent hashes per second performance measurement while generating.</para>
        /// <para>See the getgenerate and setgenerate calls to turn generation on and off.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns>(numeric) The recent hashes per second when generation is on (will return 0 if generation is off)</returns>
        public Task<RpcResponse<int>> GetHashesPerSecAsync()
        {
            return GetHashesPerSecAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Set 'generate' true or false to turn generation on or off.</para>
        /// <para>Generation is limited to 'genproclimit' processors, -1 is unlimited.</para>
        /// <para>See the getgenerate call for the current setting.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="generate">Set to true to turn on generation, off to turn off.</param>
        /// <param name="gen_proc_limit">Set the processor limit for when generation is on. Can be -1 for unlimited.</param>
        /// <returns>String value identifying this transaction</returns>
        public async Task<RpcResponse<object>> SetGenerateAsync(string blockchainName, string id, bool generate, int gen_proc_limit)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, GenerateAction.SetGenerateMethod, id, generate, gen_proc_limit);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Set 'generate' true or false to turn generation on or off.</para>
        /// <para>Generation is limited to 'genproclimit' processors, -1 is unlimited.</para>
        /// <para>See the getgenerate call for the current setting.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="generate">Set to true to turn on generation, off to turn off.</param>
        /// <param name="gen_proc_limit">Set the processor limit for when generation is on. Can be -1 for unlimited.</param>
        /// <returns>String value identifying this transaction</returns>
        public Task<RpcResponse<object>> SetGenerateAsync(bool generate, int gen_proc_limit)
        {
            return SetGenerateAsync(BlockchainOptions.ChainName, UUID.NoHyphens, generate, gen_proc_limit);
        }
    }
}