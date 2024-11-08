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
    public partial class AccountLeaderboardSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Account name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Account
        {
            get { return BackingStore?.Get<string?>("account"); }
            set { BackingStore?.Set("account", value); }
        }
#nullable restore
#else
        public string Account
        {
            get { return BackingStore?.Get<string>("account"); }
            set { BackingStore?.Set("account", value); }
        }
#endif
        /// <summary>Achievements points.</summary>
        public int? AchievementsPoints
        {
            get { return BackingStore?.Get<int?>("achievements_points"); }
            set { BackingStore?.Set("achievements_points", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Position in the leaderboard.</summary>
        public int? Position
        {
            get { return BackingStore?.Get<int?>("position"); }
            set { BackingStore?.Set("position", value); }
        }
        /// <summary>Member status.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.AccountStatus? Status
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.AccountStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AccountLeaderboardSchema"/> and sets the default values.
        /// </summary>
        public AccountLeaderboardSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AccountLeaderboardSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.AccountLeaderboardSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.AccountLeaderboardSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "account", n => { Account = n.GetStringValue(); } },
                { "achievements_points", n => { AchievementsPoints = n.GetIntValue(); } },
                { "position", n => { Position = n.GetIntValue(); } },
                { "status", n => { Status = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AccountStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("account", Account);
            writer.WriteIntValue("achievements_points", AchievementsPoints);
            writer.WriteIntValue("position", Position);
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AccountStatus>("status", Status);
        }
    }
}
#pragma warning restore CS0618
