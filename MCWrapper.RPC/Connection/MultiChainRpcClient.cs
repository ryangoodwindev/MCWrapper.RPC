using MCWrapper.Ledger.Entities.ErrorHandling;
using MCWrapper.RPC.Connection.Request;
using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Connection
{
    /// <summary>
    /// Defines JSON-RPC HTTP client
    /// </summary>
    public abstract class MultiChainRpcClient
    {
        /// <summary>
        /// Instances are not permitted
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        protected MultiChainRpcClient(HttpClient httpClient, IOptions<RpcOptions> options)
        {
            RpcOptions = options.Value;
            HttpClient = httpClient;
        }

        /// <summary>
        /// HttpClient for JSON-RPC calls
        /// </summary>
        public HttpClient HttpClient { get; set; }

        /// <summary>
        /// MultiChain RPC options
        /// </summary>
        public RpcOptions RpcOptions { get; }

        /// <summary>
        /// Asynchronous blockchain transaction with parameters
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="method"></param>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<RpcResponse> TransactAsync(string blockchainName, string method, string id, params object[] args)
        {
            var request = CreateRequest(new RpcRequest(id, method, args, blockchainName));

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            var httpResponse = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var response = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
                return fastJSON.JSON.ToObject<RpcResponse>(response);

            throw new ClientException(response)
            {
                StatusCode = (int)httpResponse.StatusCode,
                Content = response
            };
        }

        /// <summary>
        /// Asynchronous blockchain transaction with Typed object
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public async Task<RpcResponse> TransactAsync(RpcRequest serviceRequest)
        {
            var request = CreateRequest(serviceRequest);

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            var httpResponse = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var response = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
                return fastJSON.JSON.ToObject<RpcResponse>(response);

            throw new ClientException(response)
            {
                StatusCode = (int)httpResponse.StatusCode,
                Content = response
            };
        }

        /// <summary>
        /// Asynchronous blockchain transaction with parameters
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="method"></param>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<RpcResponse<T>> TransactAsync<T>(string blockchainName, string method, string id, params object[] args)
        {
            var request = CreateRequest(new RpcRequest(id, method, args, blockchainName));

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            var httpResponse = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var response = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
                return fastJSON.JSON.ToObject<RpcResponse<T>>(response);

            throw new ClientException(response)
            {
                StatusCode = (int)httpResponse.StatusCode,
                Content = response
            };
        }

        /// <summary>
        /// Asynchronous blockchain transaction with Typed object
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public async Task<RpcResponse<T>> TransactAsync<T>(RpcRequest serviceRequest)
        {
            var request = CreateRequest(serviceRequest);

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            var httpResponse = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var response = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
                return fastJSON.JSON.ToObject<RpcResponse<T>>(response);

            throw new ClientException(response)
            {
                StatusCode = (int)httpResponse.StatusCode,
                Content = response
            };
        }

        /// <summary>
        /// Return a new HttpRequestMessage instance
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        private static HttpRequestMessage CreateRequest(RpcRequest serviceRequest) =>
            new HttpRequestMessage(HttpMethod.Post, "")
            {
                // create a new ServiceRequest using the provided method, id, and argument (args) values
                Content = new StringContent(
                    content: fastJSON.JSON.ToJSON(serviceRequest.GetNamedValues, new fastJSON.JSONParameters { UseExtensions = false, EnableAnonymousTypes = true, SerializeToLowerCaseNames = true }),
                    encoding: Encoding.UTF8,
                    mediaType: RpcUrlComponent.JsonRPCMediaType)
            };

    }
}
