using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Ledger.Entities.BaseEntity;
using Newtonsoft.Json;
using System;

namespace MCWrapper.RPC.Ledger.Entities
{
    /// <summary>
    /// TxFilterEntity is POCO representation of a Transaction (Tx) filter for MultiChain Core
    /// </summary>
    public class TxFilterEntity : ChainEntity
    {
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
        /// TxFilterRestrictions property
        /// </summary>
        public TxFilterRestrictions Restrictions
        {
            get => _restrictions;
            set => _restrictions = value;
        }
        private TxFilterRestrictions _restrictions = new TxFilterRestrictions();

        /// <summary>
        /// Create a new TxFilterEntity instance
        /// </summary>
        public TxFilterEntity()
            : base(string.Empty, Entity.TxFilter) => SetEntityNameAsUUID();

        /// <summary>
        /// Create a new TxFilterEntity instance with name parameter
        /// </summary>
        /// <param name="name"></param>
        public TxFilterEntity(string name)
            : base(name, Entity.TxFilter) { }

        /// <summary>
        /// Create a new TxFilterEntity instance with name and restrictions parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="restrictions"></param>
        public TxFilterEntity(string name, TxFilterRestrictions restrictions)
            : base(name, Entity.TxFilter) => _restrictions = restrictions;

        /// <summary>
        /// Create a new TxFilterEntity instance with name, restrictions, and javaScriptCode parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="restrictions"></param>
        /// <param name="javaScriptCode"></param>
        public TxFilterEntity(string name, TxFilterRestrictions restrictions, string javaScriptCode)
            : base(name, Entity.TxFilter)
        {
            _restrictions = restrictions;
            _javaScriptCode = javaScriptCode;
        }
    }

    /// <summary>
    /// An easy to use object for passing transaction (Tx) filter permissions
    /// Must pass string[] or plain string value
    /// <para> "for" (string, optional) Asset/stream identifier - one of: create txid, stream reference, stream name. </para>
    /// <para> or </para>
    /// <para> "for" (array, optional) A json array of asset/stream string identifiers. </para>
    /// </summary>
    public class TxFilterRestrictions
    {
        /// <summary>
        /// 
        /// </summary>
        public TxFilterRestrictions() { }

        /// <summary>
        /// Create a new TxFilterRestrictions; _for value is required.
        /// Must pass string[] or plain string value passed to constructor
        /// <para> "for" (string, optional) Asset/stream identifier - one of: create txid, stream reference, stream name. </para>
        /// <para> or </para>
        /// <para> "for" (array, optional) A json array of asset/stream string identifiers. </para>
        /// </summary>
        /// <param name="_for"></param>
        public TxFilterRestrictions(object _for)
        {
            this._for = _for;
        }

        /// <summary>
        /// <para> "for" (string, optional) Asset/stream identifier - one of: create txid, stream reference, stream name. </para>
        /// <para> or </para>
        /// <para> "for" (array, optional) A json array of asset/stream string identifiers. </para>
        /// </summary>
        [JsonProperty(PropertyName = "for")]
        public object _For
        {
            get => _for;
            set => _for = ValidateTypeInput(value);
        }
        private object _for = new object();

        /// <summary>
        /// Validate the Type provided by the subscriber; We only accept string or string[] data types
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private object ValidateTypeInput(object value)
        {
            switch (value)
            {
                case string str:
                    return str;

                case string[] arr:
                    return arr;

                default:
                    throw new ArgumentException
                        ($"{nameof(TxFilterRestrictions)} property {nameof(_for)} can only be assigned as string or string[] Types. Type {value.GetType()} is not an assignable Type.");
            }
        }
    }
}