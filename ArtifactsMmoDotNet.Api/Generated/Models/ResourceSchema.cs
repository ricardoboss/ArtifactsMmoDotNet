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
    public partial class ResourceSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The code of the resource. This is the resource&apos;s unique identifier (ID).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Code
        {
            get { return BackingStore?.Get<string?>("code"); }
            set { BackingStore?.Set("code", value); }
        }
#nullable restore
#else
        public string Code
        {
            get { return BackingStore?.Get<string>("code"); }
            set { BackingStore?.Set("code", value); }
        }
#endif
        /// <summary>The drops of this resource.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.DropRateSchema>? Drops
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.DropRateSchema>?>("drops"); }
            set { BackingStore?.Set("drops", value); }
        }
#nullable restore
#else
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.DropRateSchema> Drops
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.DropRateSchema>>("drops"); }
            set { BackingStore?.Set("drops", value); }
        }
#endif
        /// <summary>The skill level required to gather this resource.</summary>
        public int? Level
        {
            get { return BackingStore?.Get<int?>("level"); }
            set { BackingStore?.Set("level", value); }
        }
        /// <summary>The name of the resource</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name
        {
            get { return BackingStore?.Get<string?>("name"); }
            set { BackingStore?.Set("name", value); }
        }
#nullable restore
#else
        public string Name
        {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
#endif
        /// <summary>The skill required to gather this resource.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.GatheringSkill? Skill
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.GatheringSkill?>("skill"); }
            set { BackingStore?.Set("skill", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.ResourceSchema"/> and sets the default values.
        /// </summary>
        public ResourceSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.ResourceSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.ResourceSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.ResourceSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "code", n => { Code = n.GetStringValue(); } },
                { "drops", n => { Drops = n.GetCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.DropRateSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.DropRateSchema.CreateFromDiscriminatorValue)?.AsList(); } },
                { "level", n => { Level = n.GetIntValue(); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "skill", n => { Skill = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.GatheringSkill>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("code", Code);
            writer.WriteCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.DropRateSchema>("drops", Drops);
            writer.WriteIntValue("level", Level);
            writer.WriteStringValue("name", Name);
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.GatheringSkill>("skill", Skill);
        }
    }
}
#pragma warning restore CS0618
