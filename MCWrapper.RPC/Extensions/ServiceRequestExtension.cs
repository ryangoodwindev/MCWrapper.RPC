using MCWrapper.RPC.Connection.Request;
using MCWrapper.RPC.Constants;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MCWrapper.RPC.Extensions
{
    /// <summary>
    /// Offers extensions methods for ServiceRequest objects
    /// </summary>
    public static class ServiceRequestExtension
    {
        /// <summary>
        /// Serialize ServiceRequest object to JSON formatted string
        /// </summary>
        /// <param name="request">RpcRequest type</param>
        /// <returns></returns>
        public static StringContent ToStringContent(this RpcRequest request)
        {
            // serialize ServiceRequest object to JSON formatted string
            // define HTTP StringContent, define Enconding, and MediaType
            return new StringContent(
                content: JsonConvert.SerializeObject(request.GetNamedValues),
                encoding: Encoding.UTF8,
                mediaType: ClientUrlComponent.JsonRPCMediaType);
        }
    }
}