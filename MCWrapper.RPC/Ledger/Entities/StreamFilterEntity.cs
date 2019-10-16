using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Ledger.Entities.BaseEntity;

namespace MCWrapper.RPC.Ledger.Entities
{
    /// <summary>
    /// StreamFilterEntity is POCO representation of a Stream filter for MultiChain Core
    /// </summary>
    public class StreamFilterEntity : ChainEntity
    {
        /// <summary>
        /// StreamFilterRestrictions property
        /// </summary>
        public StreamFilterRestrictions Restrictions
        {
            get => _restrictions;
            set => _restrictions = value;
        }
        private StreamFilterRestrictions _restrictions = new StreamFilterRestrictions();

        /// <summary>
        /// Plain string value in JavaScript syntax
        /// </summary>
        public string JavaScriptCode
        {
            get => _javaScriptCode;
            set => _javaScriptCode = value;
        }
        private string _javaScriptCode = string.Empty;

        /// <summary>
        /// Create a new StreamFilterEntity
        /// </summary>
        public StreamFilterEntity()
            : base(string.Empty, Entity.StreamFilter) { }

        /// <summary>
        /// Creaes a new StreamEntity instance with name parameter
        /// </summary>
        /// <param name="name"></param>
        public StreamFilterEntity(string name)
            : base(name, Entity.StreamFilter) { }

        /// <summary>
        /// Creaes a new StreamEntity instance with name and restrictions parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="restrictions"></param>
        public StreamFilterEntity(string name, StreamFilterRestrictions restrictions)
            : base(name, Entity.StreamFilter) => _restrictions = restrictions;

        /// <summary>
        /// Creaes a new StreamEntity instance with name and restrictions parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="restrictions"></param>
        /// <param name="javaScriptCode"></param>
        public StreamFilterEntity(string name, StreamFilterRestrictions restrictions, string javaScriptCode)
            : base(name, Entity.StreamFilter)
        {
            _restrictions = restrictions;
            _javaScriptCode = javaScriptCode;
        }
    }

    /// <summary>
    /// An easy to use object for passing stream filter permissions
    /// </summary>
    public class StreamFilterRestrictions
    {

    }
}
