using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Options;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace MCWrapper.RPC.Connection
{
    /// <summary>
    /// Offers methods to construct MultiChain blockchain Service URL and AuthenticationHeaderValue
    /// </summary> 
    public sealed class ConnectionHelper
    {
        /// <summary>
        /// Construct MultiChain blockchain Service URL
        /// </summary>
        /// <returns></returns>
        public static string GetServiceUrl(RpcOptions options) => string.Format(RpcUrlComponent.Format,
                options.ChainUseSsl == true ? RpcUrlComponent.Https : RpcUrlComponent.Http, options.ChainHostname, options.ChainRpcPort);

        /// <summary>
        /// Construct Authentication Header Value
        /// </summary>
        /// <returns></returns>
        public static AuthenticationHeaderValue GetAuthenticationHeaderValue(RpcOptions options) => 
            new AuthenticationHeaderValue(RpcUrlComponent.BasicHeaderValue, Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", options.ChainUsername, options.ChainPassword))));
    }
}