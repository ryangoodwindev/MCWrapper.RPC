using MCWrapper.Ledger.Entities.ErrorHandling;
using MCWrapper.RPC.Connection.Request;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Connection
{
    /// <summary>
    /// Defines JSON-RPC HTTP client
    /// </summary>
    public abstract class RpcClient
    {
        /// <summary>
        /// Instances are not permitted
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        protected RpcClient(HttpClient httpClient, IOptions<RpcOptions> options)
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
        public async Task<T> TransactAsync<T>(string blockchainName, string method, string id, params object[] args)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "")
            {
                // create a new ServiceRequest using the provided method, id, and argument (args) values
                Content = new RpcRequest(id, method, args, blockchainName).ToStringContent()
            };

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            using var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, new CancellationToken());

            using var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
                return DeserializeJsonFromStream<T>(stream);

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
        public async Task<T> TransactAsync<T>(RpcRequest serviceRequest)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "")
            {
                // create a new ServiceRequest using the provided method, id, and argument (args) values
                Content = serviceRequest.ToStringContent()
            };

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            using var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, new CancellationToken());

            using var stream = await response.Content.ReadAsStreamAsync();

            if (response.IsSuccessStatusCode)
                return DeserializeJsonFromStream<T>(stream);

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

            return result;
        }

        /// <summary>
        /// Get a string from a stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string? content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content ?? string.Empty;
        }
    }
}
