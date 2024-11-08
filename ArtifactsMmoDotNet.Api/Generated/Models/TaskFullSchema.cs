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
    public partial class TaskFullSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Task objective.</summary>
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
        /// <summary>Task level.</summary>
        public int? Level
        {
            get { return BackingStore?.Get<int?>("level"); }
            set { BackingStore?.Set("level", value); }
        }
        /// <summary>Maximum amount of task.</summary>
        public int? MaxQuantity
        {
            get { return BackingStore?.Get<int?>("max_quantity"); }
            set { BackingStore?.Set("max_quantity", value); }
        }
        /// <summary>Minimum amount of task.</summary>
        public int? MinQuantity
        {
            get { return BackingStore?.Get<int?>("min_quantity"); }
            set { BackingStore?.Set("min_quantity", value); }
        }
        /// <summary>Rewards.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.TaskRewardsSchema? Rewards
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskRewardsSchema?>("rewards"); }
            set { BackingStore?.Set("rewards", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.TaskRewardsSchema Rewards
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskRewardsSchema>("rewards"); }
            set { BackingStore?.Set("rewards", value); }
        }
#endif
        /// <summary>Skill required to complete the task.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill? Skill
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill?>("skill"); }
            set { BackingStore?.Set("skill", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill Skill
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill>("skill"); }
            set { BackingStore?.Set("skill", value); }
        }
#endif
        /// <summary>The type of task.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.TaskType? Type
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema"/> and sets the default values.
        /// </summary>
        public TaskFullSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema();
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
                { "level", n => { Level = n.GetIntValue(); } },
                { "max_quantity", n => { MaxQuantity = n.GetIntValue(); } },
                { "min_quantity", n => { MinQuantity = n.GetIntValue(); } },
                { "rewards", n => { Rewards = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskRewardsSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.TaskRewardsSchema.CreateFromDiscriminatorValue); } },
                { "skill", n => { Skill = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill>(global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill.CreateFromDiscriminatorValue); } },
                { "type", n => { Type = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskType>(); } },
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
            writer.WriteIntValue("level", Level);
            writer.WriteIntValue("max_quantity", MaxQuantity);
            writer.WriteIntValue("min_quantity", MinQuantity);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskRewardsSchema>("rewards", Rewards);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill>("skill", Skill);
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.TaskType>("type", Type);
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="Null"/>, <see cref="string"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class TaskFullSchema_skill : IBackedModel, IComposedTypeWrapper, IParsable
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
            /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill"/> and sets the default values.
            /// </summary>
            public TaskFullSchema_skill()
            {
                BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::ArtifactsMmoDotNet.Api.Generated.Models.TaskFullSchema.TaskFullSchema_skill();
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
