using System.Collections.Generic;

namespace MCWrapper.RPC.Constants
{
    /// <summary>
    /// A strongly typed method to say we are using or paying in the native currency
    /// </summary>
    public struct NativeCurrency
    {
        /// <summary>
        /// Just an empty string as that is how MultiChain Core represents local currency
        /// </summary>
        public const string CoinVerb = "";

        /// <summary>
        /// Return a dictionary representing a native currency object
        /// </summary>
        /// <param name="n_coins"></param>
        /// <returns></returns>
        public static Dictionary<string, decimal> Coins(decimal n_coins) => 
            new Dictionary<string, decimal> { { CoinVerb, n_coins } };
    }
}