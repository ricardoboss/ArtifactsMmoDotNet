// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    #pragma warning disable CS1591
    public partial class CraftSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>List of items required to craft the item.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema>? Items
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema>?>("items"); }
            set { BackingStore?.Set("items", value); }
        }
#nullable restore
#else
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema> Items
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema>>("items"); }
            set { BackingStore?.Set("items", value); }
        }
#endif
        /// <summary>The skill level required to craft the item.</summary>
        public int? Level
        {
            get { return BackingStore?.Get<int?>("level"); }
            set { BackingStore?.Set("level", value); }
        }
        /// <summary>Quantity of items crafted.</summary>
        public int? Quantity
        {
            get { return BackingStore?.Get<int?>("quantity"); }
            set { BackingStore?.Set("quantity", value); }
        }
        /// <summary>Skill required to craft the item.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.CraftSkill? Skill
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.CraftSkill?>("skill"); }
            set { BackingStore?.Set("skill", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.CraftSchema"/> and sets the default values.
        /// </summary>
        public CraftSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.CraftSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.CraftSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.CraftSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "items", n => { Items = n.GetCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema.CreateFromDiscriminatorValue)?.AsList(); } },
                { "level", n => { Level = n.GetIntValue(); } },
                { "quantity", n => { Quantity = n.GetIntValue(); } },
                { "skill", n => { Skill = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.CraftSkill>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema>("items", Items);
            writer.WriteIntValue("level", Level);
            writer.WriteIntValue("quantity", Quantity);
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.CraftSkill>("skill", Skill);
        }
    }
}
#pragma warning restore CS0618
