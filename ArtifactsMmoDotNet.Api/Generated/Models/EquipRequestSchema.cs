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
    public partial class EquipRequestSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Player details.</summary>
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
        /// <summary>Item details.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.ItemSchema? Item
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.ItemSchema?>("item"); }
            set { BackingStore?.Set("item", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.ItemSchema Item
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.ItemSchema>("item"); }
            set { BackingStore?.Set("item", value); }
        }
#endif
        /// <summary>Item slot.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.EquipRequestSchema_slot? Slot
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.EquipRequestSchema_slot?>("slot"); }
            set { BackingStore?.Set("slot", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.EquipRequestSchema"/> and sets the default values.
        /// </summary>
        public EquipRequestSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.EquipRequestSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.EquipRequestSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.EquipRequestSchema();
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
                { "item", n => { Item = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.ItemSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.ItemSchema.CreateFromDiscriminatorValue); } },
                { "slot", n => { Slot = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.EquipRequestSchema_slot>(); } },
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
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.ItemSchema>("item", Item);
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.EquipRequestSchema_slot>("slot", Slot);
        }
    }
}
