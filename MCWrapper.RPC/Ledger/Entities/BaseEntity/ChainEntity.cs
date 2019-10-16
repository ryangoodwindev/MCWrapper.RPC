using Newtonsoft.Json;
using System;

namespace MCWrapper.RPC.Ledger.Entities.BaseEntity
{
    /// <summary>
    /// BaseChainEntity will be inherited by Asset, Stream, and StreamFilter blockchain entity models
    /// </summary>
    public class ChainEntity
    {
        /// <summary>
        /// Stream name, if not "" should be unique.
        /// <para>
        ///     Use the SetRandomName() method to assign a random UUID value to Name
        /// </para>
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        private string _name = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string EntityType
        {
            get => _entityType;
        }
        private readonly string _entityType = string.Empty;

        /// <summary>
        /// Create a new BaseChainEntity instance with no parameters
        /// </summary>
        public ChainEntity() { }

        /// <summary>
        /// Create a new BaseChainEntity instance with name parameter
        /// </summary>
        /// <param name="name"></param>
        public ChainEntity(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Create a new BaseChainEntity with name and entityType parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="entityType"></param>
        public ChainEntity(string name, string entityType) : this(name)
        {
            _entityType = entityType;
        }

        /// <summary>
        /// Generate a 22-character UUID;
        /// Want to use your own UUID? Go ahead;
        /// This method can be called to assign a UUID to the Name property 
        /// and will return that same UUID string to the subscriber when called
        /// </summary>
        public void SetEntityNameAsUUID()
        {
            // generate a new Guid (36 characters)
            var newGuid = Guid.NewGuid();

            // convert and truncate Guid to 24 character UUID
            var newUuid = Convert.ToBase64String(newGuid.ToByteArray());

            // truncate the '==' trailing characters which results in a 22 character UUID
            var truncUuid = newUuid.Remove(newUuid.Length - 2);

            _name = truncUuid;
        }

        /// <summary>
        /// Generate a 22-character UUID;
        /// Want to use your own UUID? Go ahead;
        /// This method can be called to assign a UUID to the Name property 
        /// and will return that same UUID string to the subscriber when called
        /// </summary>
        public static string GetUUID()
        {
            // generate a new Guid (36 characters)
            var newGuid = Guid.NewGuid();

            // convert and truncate Guid to 24 character UUID
            var newUuid = Convert.ToBase64String(newGuid.ToByteArray());

            // truncate the '==' trailing characters which results in a 22 character UUID
            var truncUuid = newUuid.Remove(newUuid.Length - 2);

            return truncUuid;
        }
    }
}
