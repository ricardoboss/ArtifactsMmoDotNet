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
    public partial class AchievementSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Code of the achievement. </summary>
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
        /// <summary>Completed at.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at? CompletedAt
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at?>("completed_at"); }
            set { BackingStore?.Set("completed_at", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at CompletedAt
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at>("completed_at"); }
            set { BackingStore?.Set("completed_at", value); }
        }
#endif
        /// <summary>Current progress.</summary>
        public int? Current
        {
            get { return BackingStore?.Get<int?>("current"); }
            set { BackingStore?.Set("current", value); }
        }
        /// <summary>Description of the achievement.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description
        {
            get { return BackingStore?.Get<string?>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#nullable restore
#else
        public string Description
        {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#endif
        /// <summary>Name of the achievement.</summary>
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
        /// <summary>Points of the achievement. Used for the leaderboard.</summary>
        public int? Points
        {
            get { return BackingStore?.Get<int?>("points"); }
            set { BackingStore?.Set("points", value); }
        }
        /// <summary>Target of the achievement.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target? Target
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target?>("target"); }
            set { BackingStore?.Set("target", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target Target
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target>("target"); }
            set { BackingStore?.Set("target", value); }
        }
#endif
        /// <summary>Total to do.</summary>
        public int? Total
        {
            get { return BackingStore?.Get<int?>("total"); }
            set { BackingStore?.Set("total", value); }
        }
        /// <summary>Type of achievement.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema_type? Type
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema_type?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema"/> and sets the default values.
        /// </summary>
        public AchievementSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema();
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
                { "completed_at", n => { CompletedAt = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at>(global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at.CreateFromDiscriminatorValue); } },
                { "current", n => { Current = n.GetIntValue(); } },
                { "description", n => { Description = n.GetStringValue(); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "points", n => { Points = n.GetIntValue(); } },
                { "target", n => { Target = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target>(global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target.CreateFromDiscriminatorValue); } },
                { "total", n => { Total = n.GetIntValue(); } },
                { "type", n => { Type = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema_type>(); } },
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
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at>("completed_at", CompletedAt);
            writer.WriteIntValue("current", Current);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("name", Name);
            writer.WriteIntValue("points", Points);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target>("target", Target);
            writer.WriteIntValue("total", Total);
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema_type>("type", Type);
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="DateTimeOffset"/>, <see cref="Null"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class AchievementSchema_completed_at : IBackedModel, IComposedTypeWrapper, IParsable
        {
            /// <summary>Stores model information.</summary>
            public IBackingStore BackingStore { get; private set; }
            /// <summary>Composed type representation for type <see cref="DateTimeOffset"/></summary>
            public DateTimeOffset? DateTimeOffset
            {
                get { return BackingStore?.Get<DateTimeOffset?>("DateTimeOffset"); }
                set { BackingStore?.Set("DateTimeOffset", value); }
            }
            /// <summary>Composed type representation for type <see cref="Null"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Null? Null
            {
                get { return BackingStore?.Get<Null?>("null"); }
                set { BackingStore?.Set("null", value); }
            }
#nullable restore
#else
            public Null Null
            {
                get { return BackingStore?.Get<Null>("null"); }
                set { BackingStore?.Set("null", value); }
            }
#endif
            /// <summary>
            /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at"/> and sets the default values.
            /// </summary>
            public AchievementSchema_completed_at()
            {
                BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_completed_at();
                if(parseNode.GetDateTimeOffsetValue() is DateTimeOffset dateTimeOffsetValue)
                {
                    result.DateTimeOffset = dateTimeOffsetValue;
                }
                else if(parseNode.GetObjectValue<Null>(Null.CreateFromDiscriminatorValue) is Null nullValue)
                {
                    result.Null = nullValue;
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
            public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
            {
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public virtual void Serialize(ISerializationWriter writer)
            {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(DateTimeOffset != null)
                {
                    writer.WriteDateTimeOffsetValue(null, DateTimeOffset);
                }
                else if(Null != null)
                {
                    writer.WriteObjectValue<Null>(null, Null);
                }
            }
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="Null"/>, <see cref="string"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class AchievementSchema_target : IBackedModel, IComposedTypeWrapper, IParsable
        {
            /// <summary>Stores model information.</summary>
            public IBackingStore BackingStore { get; private set; }
            /// <summary>Composed type representation for type <see cref="Null"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public Null? Null
            {
                get { return BackingStore?.Get<Null?>("null"); }
                set { BackingStore?.Set("null", value); }
            }
#nullable restore
#else
            public Null Null
            {
                get { return BackingStore?.Get<Null>("null"); }
                set { BackingStore?.Set("null", value); }
            }
#endif
            /// <summary>Composed type representation for type <see cref="string"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? String
            {
                get { return BackingStore?.Get<string?>("string"); }
                set { BackingStore?.Set("string", value); }
            }
#nullable restore
#else
            public string String
            {
                get { return BackingStore?.Get<string>("string"); }
                set { BackingStore?.Set("string", value); }
            }
#endif
            /// <summary>
            /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target"/> and sets the default values.
            /// </summary>
            public AchievementSchema_target()
            {
                BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::ArtifactsMmoDotNet.Api.Generated.Models.AchievementSchema.AchievementSchema_target();
                if(parseNode.GetObjectValue<Null>(Null.CreateFromDiscriminatorValue) is Null nullValue)
                {
                    result.Null = nullValue;
                }
                else if(parseNode.GetStringValue() is string stringValue)
                {
                    result.String = stringValue;
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
            public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
            {
                return new Dictionary<string, Action<IParseNode>>();
            }
            /// <summary>
            /// Serializes information the current object
            /// </summary>
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            public virtual void Serialize(ISerializationWriter writer)
            {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                if(Null != null)
                {
                    writer.WriteObjectValue<Null>(null, Null);
                }
                else if(String != null)
                {
                    writer.WriteStringValue(null, String);
                }
            }
        }
    }
}
#pragma warning restore CS0618
