using System;

namespace MCWrapper.RPC.ErrorHandling
{
    /// <summary>
    /// Handles any exception thrown from the BlockchainProfileOptions class
    /// </summary>
    public class ProfileException : Exception
    {
        /// <summary>
        /// Generate custom BlockchainProfileOptions exception
        /// </summary>
        /// <param name="message"></param>
        public ProfileException(string message) : base(message) { }
    }
}
