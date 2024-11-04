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
    public partial class FightSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The items dropped by the fight.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.DropSchema>? Drops
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.DropSchema>?>("drops"); }
            set { BackingStore?.Set("drops", value); }
        }
#nullable restore
#else
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.DropSchema> Drops
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.DropSchema>>("drops"); }
            set { BackingStore?.Set("drops", value); }
        }
#endif
        /// <summary>The amount of gold gained by the fight.</summary>
        public int? Gold
        {
            get { return BackingStore?.Get<int?>("gold"); }
            set { BackingStore?.Set("gold", value); }
        }
        /// <summary>The fight logs.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Logs
        {
            get { return BackingStore?.Get<List<string>?>("logs"); }
            set { BackingStore?.Set("logs", value); }
        }
#nullable restore
#else
        public List<string> Logs
        {
            get { return BackingStore?.Get<List<string>>("logs"); }
            set { BackingStore?.Set("logs", value); }
        }
#endif
        /// <summary>The amount of blocked hits by the monster.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema? MonsterBlockedHits
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema?>("monster_blocked_hits"); }
            set { BackingStore?.Set("monster_blocked_hits", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema MonsterBlockedHits
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema>("monster_blocked_hits"); }
            set { BackingStore?.Set("monster_blocked_hits", value); }
        }
#endif
        /// <summary>The amount of blocked hits by the player.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema? PlayerBlockedHits
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema?>("player_blocked_hits"); }
            set { BackingStore?.Set("player_blocked_hits", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema PlayerBlockedHits
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema>("player_blocked_hits"); }
            set { BackingStore?.Set("player_blocked_hits", value); }
        }
#endif
        /// <summary>The result of the fight.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.FightResult? Result
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.FightResult?>("result"); }
            set { BackingStore?.Set("result", value); }
        }
        /// <summary>Numbers of the turns of the combat.</summary>
        public int? Turns
        {
            get { return BackingStore?.Get<int?>("turns"); }
            set { BackingStore?.Set("turns", value); }
        }
        /// <summary>The amount of xp gained by the fight.</summary>
        public int? Xp
        {
            get { return BackingStore?.Get<int?>("xp"); }
            set { BackingStore?.Set("xp", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.FightSchema"/> and sets the default values.
        /// </summary>
        public FightSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.FightSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.FightSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.FightSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "drops", n => { Drops = n.GetCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.DropSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.DropSchema.CreateFromDiscriminatorValue)?.AsList(); } },
                { "gold", n => { Gold = n.GetIntValue(); } },
                { "logs", n => { Logs = n.GetCollectionOfPrimitiveValues<string>()?.AsList(); } },
                { "monster_blocked_hits", n => { MonsterBlockedHits = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema.CreateFromDiscriminatorValue); } },
                { "player_blocked_hits", n => { PlayerBlockedHits = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema.CreateFromDiscriminatorValue); } },
                { "result", n => { Result = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.FightResult>(); } },
                { "turns", n => { Turns = n.GetIntValue(); } },
                { "xp", n => { Xp = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.DropSchema>("drops", Drops);
            writer.WriteIntValue("gold", Gold);
            writer.WriteCollectionOfPrimitiveValues<string>("logs", Logs);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema>("monster_blocked_hits", MonsterBlockedHits);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.BlockedHitsSchema>("player_blocked_hits", PlayerBlockedHits);
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.FightResult>("result", Result);
            writer.WriteIntValue("turns", Turns);
            writer.WriteIntValue("xp", Xp);
        }
    }
}
#pragma warning restore CS0618
