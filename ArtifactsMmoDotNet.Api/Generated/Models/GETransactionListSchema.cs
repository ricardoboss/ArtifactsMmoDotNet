// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.16.0")]
    #pragma warning disable CS1591
    public partial class GETransactionListSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Character details.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.CharacterSchema? Character
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.CharacterSchema?>("character"); }
            set { BackingStore?.Set("character", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.CharacterSchema Character
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.CharacterSchema>("character"); }
            set { BackingStore?.Set("character", value); }
        }
#endif
        /// <summary>Cooldown details.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.CooldownSchema? Cooldown
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.CooldownSchema?>("cooldown"); }
            set { BackingStore?.Set("cooldown", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.CooldownSchema Cooldown
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.CooldownSchema>("cooldown"); }
            set { BackingStore?.Set("cooldown", value); }
        }
#endif
        /// <summary>Transaction details.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionSchema? Transaction
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionSchema?>("transaction"); }
            set { BackingStore?.Set("transaction", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionSchema Transaction
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionSchema>("transaction"); }
            set { BackingStore?.Set("transaction", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionListSchema"/> and sets the default values.
        /// </summary>
        public GETransactionListSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionListSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionListSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionListSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "character", n => { Character = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.CharacterSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.CharacterSchema.CreateFromDiscriminatorValue); } },
                { "cooldown", n => { Cooldown = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.CooldownSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.CooldownSchema.CreateFromDiscriminatorValue); } },
                { "transaction", n => { Transaction = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionSchema.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.CharacterSchema>("character", Character);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.CooldownSchema>("cooldown", Cooldown);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.GETransactionSchema>("transaction", Transaction);
        }
    }
}
