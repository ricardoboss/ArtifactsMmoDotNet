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
    public partial class ActiveEventSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Code of the event. This is the event&apos;s unique identifier (ID).</summary>
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
        /// <summary>Start datetime.</summary>
        public DateTimeOffset? CreatedAt
        {
            get { return BackingStore?.Get<DateTimeOffset?>("created_at"); }
            set { BackingStore?.Set("created_at", value); }
        }
        /// <summary>Duration in minutes.</summary>
        public int? Duration
        {
            get { return BackingStore?.Get<int?>("duration"); }
            set { BackingStore?.Set("duration", value); }
        }
        /// <summary>Expiration datetime.</summary>
        public DateTimeOffset? Expiration
        {
            get { return BackingStore?.Get<DateTimeOffset?>("expiration"); }
            set { BackingStore?.Set("expiration", value); }
        }
        /// <summary>Map of the event.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.MapSchema? Map
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.MapSchema?>("map"); }
            set { BackingStore?.Set("map", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.MapSchema Map
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.MapSchema>("map"); }
            set { BackingStore?.Set("map", value); }
        }
#endif
        /// <summary>Name of the event.</summary>
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
        /// <summary>Previous map skin.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PreviousSkin
        {
            get { return BackingStore?.Get<string?>("previous_skin"); }
            set { BackingStore?.Set("previous_skin", value); }
        }
#nullable restore
#else
        public string PreviousSkin
        {
            get { return BackingStore?.Get<string>("previous_skin"); }
            set { BackingStore?.Set("previous_skin", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema"/> and sets the default values.
        /// </summary>
        public ActiveEventSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema();
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
                { "created_at", n => { CreatedAt = n.GetDateTimeOffsetValue(); } },
                { "duration", n => { Duration = n.GetIntValue(); } },
                { "expiration", n => { Expiration = n.GetDateTimeOffsetValue(); } },
                { "map", n => { Map = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.MapSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.MapSchema.CreateFromDiscriminatorValue); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "previous_skin", n => { PreviousSkin = n.GetStringValue(); } },
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
            writer.WriteDateTimeOffsetValue("created_at", CreatedAt);
            writer.WriteIntValue("duration", Duration);
            writer.WriteDateTimeOffsetValue("expiration", Expiration);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.MapSchema>("map", Map);
            writer.WriteStringValue("name", Name);
            writer.WriteStringValue("previous_skin", PreviousSkin);
        }
    }
}
#pragma warning restore CS0618
