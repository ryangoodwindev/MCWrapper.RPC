using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Ledger.Entities.BaseEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MCWrapper.RPC.Ledger.Entities
{
    /// <summary>
    /// Typed object model representing a new blockchain stream
    /// </summary>
    public class StreamEntity : ChainEntity
    {
        /// <summary>
        /// Allow anyone to publish in this stream
        /// </summary>
        public bool Open
        {
            get => _open;
            set => _open = value;
        }
        private bool _open = false;

        /// <summary>
        /// Stream restrictions
        /// <para>
        ///     Stream restrictions, comma delimited. Possible values: write,offchain,onchain
        /// </para>
        /// <para>
        ///     RestrictTypes may be passed individually via AddRestriction to append values
        /// </para>
        /// </summary>
        public StreamRestrictions Restrictions
        {
            get => _restrictions;
            set => _restrictions = value;
        }
        private StreamRestrictions _restrictions = new StreamRestrictions();

        /// <summary>
        ///  a json object with custom fields
        ///  <para>
        ///     The key is the parameter name, the value is parameter value
        /// </para>
        /// </summary>
        public ConcurrentDictionary<string, string> CustomFields
        {
            get => _customFields;
            set => _customFields = value;
        }
        private ConcurrentDictionary<string, string> _customFields = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Create a new StreamChainEntity instance
        /// </summary>
        public StreamEntity()
            : base(string.Empty, Entity.Stream) => SetEntityNameAsUUID();

        /// <summary>
        /// Creaes a new StreamChainEntity instance with name parameter
        /// </summary>
        /// <param name="name"></param>
        public StreamEntity(string name)
            : base(name, Entity.Stream) { }

        /// <summary>
        /// Creates a new StreamChainEntity instance with name and open parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="open"></param>
        public StreamEntity(string name, bool open)
            : base(name, Entity.Stream) => _open = open;

        /// <summary>
        /// Creates a new StreamChainEntity instance with name, open, and restrictions parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="open"></param>
        /// <param name="restrictions"></param>
        public StreamEntity(string name, bool open, StreamRestrictions restrictions)
            : base(name, Entity.Stream)
        {
            _open = open;
            _restrictions = restrictions;
        }

        /// <summary>
        /// Creates a new StreamChainEntity instance with name, open, restrictions, and customerFields parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="open"></param>
        /// <param name="restrictions"></param>
        /// <param name="customFields"></param>
        public StreamEntity(string name, bool open, StreamRestrictions restrictions, ConcurrentDictionary<string, string> customFields)
            : base(name, Entity.Stream)
        {
            _open = open;
            _restrictions = restrictions;
            _customFields = customFields;
        }

        /// <summary>
        /// Adds or updates a key value pair
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddOrUpdateCustomField(string key, string value)
        {
            _customFields.AddOrUpdate(key, value,
                (key, existingVal) =>
                {
                    existingVal = value;
                    return existingVal;
                });
        }

        /// <summary>
        /// Removes custom field key value pair
        /// </summary>
        /// <param name="key"></param>
        public void RemoveCustomField(string key)
        {
            // remove key value pair and discard out value
            _customFields.Remove(key, out string _);
        }
    }

    /// <summary>
    /// An easy to use object for passing stream permissions
    /// </summary>
    public class StreamRestrictions
    {
        /// <summary>
        /// Create a new StreamRestrictions instance;
        /// </summary>
        public StreamRestrictions() { }

        /// <summary>
        /// Create a new StreamRestrictions instance;
        /// You can use struct RestrictTypes to populate the string[]
        /// </summary>
        /// <param name="restrictTypes">You can use struct RestrictTypes to populate the property</param>
        /// <param name="salted">Include "salted":true in restrictions to include random salt in all offchain chunks</param>
        public StreamRestrictions(string[] restrictTypes, bool salted = true)
        {
            _salted = salted;
            _restrict = string.Join(",", restrictTypes);
        }

        /// <summary>
        /// Restrict value to be passed during stream creation
        ///  <para>
        ///     Restrict property is read-only and is an empty string by default unless a restrictTypes array is passed to the object's constructor, to change it's 
        ///     value use the AddRestriction(StreamRestrictTypes restriction) / RemoveRestriction(StreamRestrictTypes restriction) methods available from this object.
        /// </para>
        /// </summary>
        [JsonProperty("restrict")]
        public string Restrict { get => _restrict; }
        private string _restrict = string.Empty;

        /// <summary>
        /// Include "salted":true in restrictions to include random salt in all offchain chunks, 
        /// to protect against dictionary attacks and ensure each chunk hash is unique. 
        /// Read-restricted streams automatically use salting and disallow on-chain items. 
        /// <para>
        ///     Salted property is read-only and is True by default, to change it's boolean 
        ///     state use the SetAsSalted() / SetAsUnSalted() methods available from this object.
        /// </para>
        /// </summary>
        [JsonProperty("salted")]
        public bool Salted { get => _salted; }
        private bool _salted = true;

        /// <summary>
        /// Add RestrictionType to Restrictions
        /// <para>
        ///     Include "salted" as true(default) in restrictions to include random salt in all offchain chunks, 
        ///     to protect against dictionary attacks and ensure each chunk hash is unique. 
        ///     Read-restricted streams automatically use salting and disallow on-chain items. 
        /// </para>
        /// </summary>
        /// <param name="restriction"></param>
        public void AddRestriction(string restriction)
        {
            var current = _restrict.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            var restrictionIsEnabled = !current.Any(a => a.Equals(restriction.ToString(), StringComparison.OrdinalIgnoreCase));

            if (!restrictionIsEnabled)
                current.Add(restriction.ToString());

            _restrict = string.Join(",", current);
        }

        /// <summary>
        /// Remove RestrictionType from Restrictions KeyValuePair
        /// </summary>
        /// <param name="restriction"></param>
        public void RemoveRestriction(string restriction)
        {
            var current = _restrict.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            var restrictionIsEnabled = current.Any(a => a.Equals(restriction.ToString(), StringComparison.OrdinalIgnoreCase));

            if (restrictionIsEnabled)
                current.Remove(restriction.ToString());

            _restrict = string.Join(",", current);
        }

        /// <summary>
        /// Set Salted property to True
        /// </summary>
        public void SetAsSalted()
        {
            _salted = true;
        }

        /// <summary>
        /// Set Salted property to False
        /// </summary>
        public void SetAsUnSalted()
        {
            _salted = false;
        }
    }

    /// <summary>
    /// Struct contains type of Restrictions that can be passed using the Create method;
    /// Generally used for creating and managing blockchain Streams;
    /// </summary>
    public struct StreamRestrictTypes
    {
        /// <summary>
        /// OffChain disallows publishing off-chain items;
        /// </summary>
        public const string OffChain = "offchain";

        /// <summary>
        /// OnChain disallows publishing on-chain items;
        /// </summary>
        public const string OnChain = "onchain";

        /// <summary>
        /// Write restricts writing to addresses with per-stream write permissions;
        /// (Writing and reading in streams with read permissions requires MultiChain Enterprise,
        /// but any node can create these streams and manage their permissions.) 
        /// </summary>
        public const string Write = "write";

        /// <summary>
        /// Read restricts reading to addresses with per-stream read permissions;
        /// (Writing and reading in streams with read permissions requires MultiChain Enterprise,
        /// but any node can create these streams and manage their permissions.) 
        /// </summary>
        public const string Read = "read";
    }
}
