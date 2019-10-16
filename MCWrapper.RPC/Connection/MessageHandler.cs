using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MCWrapper.RPC.Connection
{
    public class MessageHandler
    {
        /// <summary>
        /// Return new customized HttpClientHandler instance
        /// </summary>
        /// <returns></returns>
        public static HttpClientHandler Create()
        {
            // fetch JSON config values
            var options = new BlockchainProfileOptions();

            var clientHandler = new HttpClientHandler
            {
                PreAuthenticate = true,
                Credentials = new NetworkCredential(options.ChainUsername, options.ChainPassword),
                ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => CertificateCallback.Create(cert, errors, options.ChainSslPath)
            };

            return clientHandler;
        }

        /// <summary>
        /// Return new customized HttpClientHandler instance
        /// </summary>
        /// <returns></returns>
        public static HttpClientHandler Create(BlockchainProfileOptions options)
        {
            // fetch JSON config values
            var fallbackOptions = options ?? new BlockchainProfileOptions();

            var clientHandler = new HttpClientHandler
            {
                PreAuthenticate = true,
                Credentials = new NetworkCredential(fallbackOptions.ChainUsername, fallbackOptions.ChainPassword),
                ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => CertificateCallback.Create(cert, errors, fallbackOptions.ChainSslPath)
            };

            return clientHandler;
        }

        /// <summary>
        /// Return new customized HttpClientHandler instance
        /// </summary>
        /// <returns></returns>
        public static HttpClientHandler Create(IConfiguration configuration)
        {
            // fetch JSON config values
            var fallbackOptions = new BlockchainProfileOptions();

            var sslPath = !string.IsNullOrEmpty(configuration.GetValue<string>(nameof(BlockchainProfileOptions.ChainSslPath)))
                ? configuration.GetValue<string>(nameof(BlockchainProfileOptions.ChainSslPath))
                : fallbackOptions.ChainSslPath;

            var username = !string.IsNullOrEmpty(configuration.GetValue<string>(nameof(BlockchainProfileOptions.ChainUsername)))
                ? configuration.GetValue<string>(nameof(BlockchainProfileOptions.ChainUsername))
                : fallbackOptions.ChainUsername;

            var password = !string.IsNullOrEmpty(configuration.GetValue<string>(nameof(BlockchainProfileOptions.ChainPassword)))
                ? configuration.GetValue<string>(nameof(BlockchainProfileOptions.ChainPassword))
                : fallbackOptions.ChainPassword;

            var clientHandler = new HttpClientHandler
            {
                PreAuthenticate = true,
                Credentials = new NetworkCredential(username, password),
                ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => CertificateCallback.Create(cert, errors, sslPath)
            };

            return clientHandler;
        }

        /// <summary>
        /// Construct MultiChain blockchain Service URL
        /// </summary>
        /// <returns></returns>
        public static string GetServiceUrl()
        {
            BlockchainProfileOptions options = new BlockchainProfileOptions();

            var serviceUrl = string.Format(ClientUrlComponent.Format,
                options.ChainUseSsl == true ? ClientUrlComponent.Https : ClientUrlComponent.Http, options.ChainHostname, options.ChainRpcPort);

            return serviceUrl;
        }

        /// <summary>
        /// Construct MultiChain blockchain Service URL
        /// </summary>
        /// <returns></returns>
        public static string GetServiceUrl(BlockchainProfileOptions options)
        {
            var serviceUrl = string.Format(ClientUrlComponent.Format,
                options.ChainUseSsl == true ? ClientUrlComponent.Https : ClientUrlComponent.Http, options.ChainHostname, options.ChainRpcPort);

            return serviceUrl;
        }

        /// <summary>
        /// Construct Authentication Header Value
        /// </summary>
        /// <returns></returns>
        public static AuthenticationHeaderValue GetAuthenticationHeaderValue()
        {
            BlockchainProfileOptions options = new BlockchainProfileOptions();

            var authHeader = new AuthenticationHeaderValue(
                ClientUrlComponent.BasicHeaderValue,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", options.ChainUsername, options.ChainPassword))));

            return authHeader;
        }

        /// <summary>
        /// Construct Authentication Header Value
        /// </summary>
        /// <returns></returns>
        public static AuthenticationHeaderValue GetAuthenticationHeaderValue(BlockchainProfileOptions options)
        {
            var authHeader = new AuthenticationHeaderValue(
                ClientUrlComponent.BasicHeaderValue,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", options.ChainUsername, options.ChainPassword))));

            return authHeader;
        }
    }


    /// <summary>
    /// SSL cert callback
    /// </summary>
    internal class CertificateCallback
    {
        internal static bool Create(X509Certificate2 cert, SslPolicyErrors errors, string multiChainSslPath)
        {
            return new CertificateCallback().ValidateCallback(cert, errors, multiChainSslPath);
        }

        /// <summary>
        /// Validate certificate callback
        /// </summary>
        /// <param name="cert"></param>
        /// <param name="errors"></param>
        /// <param name="certPath"></param>
        /// <returns></returns>
        private bool ValidateCallback(X509Certificate2 cert, SslPolicyErrors errors, string certPath)
        {
            // evaluate for no cert path or certificate errors
            if (errors == SslPolicyErrors.RemoteCertificateNotAvailable || string.IsNullOrEmpty(certPath))
                return false;

            try
            {
                // if no certificaiton is passed
                if (cert == null)
                    return false;

                // read certificate from localhost
                using var x509 = new X509Certificate2(File.ReadAllBytes(certPath));

                // cert comparison
                return x509.Equals(cert);
            }
            catch (Exception)
            {
                throw; // support for Stack Unwinding and Exception Bubbling
            }
        }
    }
}
