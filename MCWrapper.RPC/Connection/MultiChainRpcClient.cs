using MCWrapper.RPC.Connection.Request;
using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using Myndblock.MultiChain.Entities.ErrorHandling;
using Newtonsoft.Json;
using System.IO;
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
        public RpcOptions RpcOptions { get; set; }

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
            var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            using var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
                return DeserializeJsonFromStream<RpcResponse>(stream);

            var message = await StreamToStringAsync(stream);
            throw new ClientException(message)
            {
                StatusCode = (int)response.StatusCode,
                Content = message
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
            var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            using var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
                return DeserializeJsonFromStream<RpcResponse>(stream);

            var message = await StreamToStringAsync(stream);
            throw new ClientException(message)
            {
                StatusCode = (int)response.StatusCode,
                Content = message
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
            var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            using var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
                return DeserializeJsonFromStream<RpcResponse<T>>(stream);

            var message = await StreamToStringAsync(stream);
            throw new ClientException(message)
            {
                StatusCode = (int)response.StatusCode,
                Content = message
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
            var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            using var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
                return DeserializeJsonFromStream<RpcResponse<T>>(stream);

            var message = await StreamToStringAsync(stream);
            throw new ClientException(message)
            {
                StatusCode = (int)response.StatusCode,
                Content = message
            };
        }

        /// <summary>
        /// Get an object from a stream
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || !stream.CanRead)
            {
                object None = new { };
                return (T)None;
            }

            using var sr = new StreamReader(stream);
            using var jtr = new JsonTextReader(sr);
            var js = new JsonSerializer();
            var result = js.Deserialize<T>(jtr);

            if (result == null)
            {
                object None = new { };
                return (T)None;
            }

            return result;
        }

        /// <summary>
        /// Get a string from a stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            if (stream != null)
            {
                using var sr = new StreamReader(stream);
                return await sr.ReadToEndAsync();
            }

            return string.Empty;
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
                    content: JsonConvert.SerializeObject(serviceRequest.GetNamedValues),
                    encoding: Encoding.UTF8,
                    mediaType: RpcUrlComponent.JsonRPCMediaType)
            };

    }
}
