namespace MCWrapper.RPC.Constants
{
    /// <summary>
    /// Types of blockchain network tasks;
    /// <para>
    ///     Generally used when Pausing and/or Resuming the blockchain using either the ControlRpcClient
    /// </para>
    /// </summary>
    public struct NodeTask
    {
        /// <summary>
        /// Represents Control task type 'incoming' as a plain string
        /// </summary>
        public const string Incoming = "incoming";

        /// <summary>
        /// Represents Control task type 'mining' as plain string
        /// </summary>
        public const string Mining = "mining";

        /// <summary>
        /// Represents Control task types 'mining,incoming' as plain comma delimited string
        /// </summary>
        public const string All = "mining,incoming";
    }
}