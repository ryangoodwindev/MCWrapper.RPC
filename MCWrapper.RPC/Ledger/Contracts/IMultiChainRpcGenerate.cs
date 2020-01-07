using MCWrapper.RPC.Connection;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// 
    /// <para>MutliChain Core methods established by the IMultiChainRpcGenerate contract</para>
    ///
    /// getgenerate, gethashespersec, setgenerate
    /// 
    /// </summary>
    public interface IMultiChainRpcGenerate : IMultiChainRpc
    {
        /// <summary>
        /// <para>Return if the server is set to generate coins or not. The default is false.</para>
        /// <para>It is set with the command line argument -gen (or bitcoin.conf setting gen)</para>
        /// <para>It can also be set with the setgenerate call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns>If the server is set to generate coins or not</returns>
        Task<RpcResponse<bool>> GetGenerateAsync();

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
        Task<RpcResponse<bool>> GetGenerateAsync(string blockchainName, string id);

        /// <summary>
        /// <para>Returns a recent hashes per second performance measurement while generating.</para>
        /// <para>See the getgenerate and setgenerate calls to turn generation on and off.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns>(numeric) The recent hashes per second when generation is on (will return 0 if generation is off)</returns>
        Task<RpcResponse<int>> GetHashesPerSecAsync();

        /// <summary>
        /// <para>Returns a recent hashes per second performance measurement while generating.</para>
        /// <para>See the getgenerate and setgenerate calls to turn generation on and off.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns>(numeric) The recent hashes per second when generation is on (will return 0 if generation is off)</returns>
        Task<RpcResponse<int>> GetHashesPerSecAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Set 'generate' true or false to turn generation on or off.</para>
        /// <para>Generation is limited to 'genproclimit' processors, -1 is unlimited.</para>
        /// <para>See the getgenerate call for the current setting.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="generate">Set to true to turn on generation, off to turn off.</param>
        /// <param name="gen_proc_limit">Set the processor limit for when generation is on. Can be -1 for unlimited.</param>
        /// <returns>String value identifying this transaction</returns>
        Task<RpcResponse> SetGenerateAsync(bool generate, int gen_proc_limit);

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
        Task<RpcResponse> SetGenerateAsync(string blockchainName, string id, bool generate, int gen_proc_limit);
    }
}