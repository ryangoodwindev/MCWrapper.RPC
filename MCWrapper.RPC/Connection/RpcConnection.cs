using MCWrapper.RPC.Connection.Request;
using MCWrapper.RPC.ErrorHandling;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Connection
{
    /// <summary>
    /// Blockchain client is used to transact with the configured MultiChain network
    /// </summary>
    public class RpcConnection
    {
        public BlockchainRpcOptions BlockchainOptions { get; set; }

        /// <summary>
        /// Property for Http Web Client
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Create a new RpcConnection object
        /// </summary>
        /// <param name="client"></param>
        public RpcConnection(HttpClient client)
        {
            // set base address for blockchain
            client.BaseAddress = new Uri(RpcMessageHandler.GetServiceUrl());
            // set Authorization header value
            client.DefaultRequestHeaders.Authorization = RpcMessageHandler.GetAuthenticationHeaderValue();

            // assign web client from factory
            _httpClient = client;

            BlockchainOptions = new BlockchainRpcOptions();
        }

        /// <summary>
        /// Create a new RpcConnection object
        /// </summary>
        /// <param name="client"></param>
        /// <param name="options"></param>
        public RpcConnection(HttpClient client, IOptions<BlockchainRpcOptions> options)
        {
            // set base address for blockchain
            client.BaseAddress = new Uri(RpcMessageHandler.GetServiceUrl(options.Value));
            // set Authorization header value
            client.DefaultRequestHeaders.Authorization = RpcMessageHandler.GetAuthenticationHeaderValue(options.Value);

            // assign web client from factory
            _httpClient = client;

            BlockchainOptions = options.Value;
        }

        /// <summary>
        /// Asynchronous blockchain transaction with parameters
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="method"></param>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<string> TransactAsync(string blockchainName, string method, string id, params object[] args)
        {
            // create a new ServiceRequest using the provided method, id, and argument (args) values
            using var httpContent = new RpcRequest(id, method, args, blockchainName).ToStringContent();

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            using var response = await _httpClient.PostAsync(string.Empty, httpContent, new CancellationToken());

            var message = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return message;

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
        public async Task<string> TransactAsync(RpcRequest serviceRequest)
        {
            // create a new ServiceRequest using the provided method, id, and argument (args) values
            using var httpContent = serviceRequest.ToStringContent();

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            using var response = await _httpClient.PostAsync(string.Empty, httpContent, new CancellationToken());

            var message = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return message;

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
        public async Task<T> TransactAsync<T>(string blockchainName, string method, string id, params object[] args)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "");
            // create a new ServiceRequest using the provided method, id, and argument (args) values
            using var httpContent = new RpcRequest(id, method, args, blockchainName).ToStringContent();
            request.Content = httpContent;

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, new CancellationToken());

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
            using var request = new HttpRequestMessage(HttpMethod.Post, "");
            // create a new ServiceRequest using the provided method, id, and argument (args) values
            using var httpContent = serviceRequest.ToStringContent();
            request.Content = httpContent;

            // post StringContent to MutltiChain blockchain network
            // read HTTP JSON string response content
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, new CancellationToken());

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
