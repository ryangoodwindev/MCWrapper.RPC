using System;

namespace MCWrapper.RPC.ErrorHandling
{
    /// <summary>
    /// BlockchainServiceException extends Exception class
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Create a new custom BlockchainServiceException
        /// </summary>
        /// <param name="message"></param>
        public ServiceException(string message) : base(message) { }
    }
}
