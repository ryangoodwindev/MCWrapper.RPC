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
        /// // serialize ServiceRequest object to JSON formatted string
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static StringContent ToStringContent(this RpcRequest request)
        {
            // serialize ServiceRequest object to JSON formatted string
            string json = JsonConvert.SerializeObject(request.GetNamedValues);

            // define HTTP StringContent, define Enconding, and MediaType
            StringContent stringContent = new StringContent(json, Encoding.UTF8, ClientUrlComponent.JsonRPCMediaType);

            // return HTTP string content
            return stringContent;
        }
    }
}
