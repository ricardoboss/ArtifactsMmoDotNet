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
    public partial class MyAccountDetails : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Achievement points.</summary>
        public int? AchievementsPoints
        {
            get { return BackingStore?.Get<int?>("achievements_points"); }
            set { BackingStore?.Set("achievements_points", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Account badges.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges? Badges
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges?>("badges"); }
            set { BackingStore?.Set("badges", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges Badges
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges>("badges"); }
            set { BackingStore?.Set("badges", value); }
        }
#endif
        /// <summary>Banned.</summary>
        public bool? Banned
        {
            get { return BackingStore?.Get<bool?>("banned"); }
            set { BackingStore?.Set("banned", value); }
        }
        /// <summary>Ban reason.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? BanReason
        {
            get { return BackingStore?.Get<string?>("ban_reason"); }
            set { BackingStore?.Set("ban_reason", value); }
        }
#nullable restore
#else
        public string BanReason
        {
            get { return BackingStore?.Get<string>("ban_reason"); }
            set { BackingStore?.Set("ban_reason", value); }
        }
#endif
        /// <summary>Email.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Email
        {
            get { return BackingStore?.Get<string?>("email"); }
            set { BackingStore?.Set("email", value); }
        }
#nullable restore
#else
        public string Email
        {
            get { return BackingStore?.Get<string>("email"); }
            set { BackingStore?.Set("email", value); }
        }
#endif
        /// <summary>Gems.</summary>
        public int? Gems
        {
            get { return BackingStore?.Get<int?>("gems"); }
            set { BackingStore?.Set("gems", value); }
        }
        /// <summary>Member status.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.AccountStatus? Status
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.AccountStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>Subscribed for the current season.</summary>
        public bool? Subscribed
        {
            get { return BackingStore?.Get<bool?>("subscribed"); }
            set { BackingStore?.Set("subscribed", value); }
        }
        /// <summary>Username.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Username
        {
            get { return BackingStore?.Get<string?>("username"); }
            set { BackingStore?.Set("username", value); }
        }
#nullable restore
#else
        public string Username
        {
            get { return BackingStore?.Get<string>("username"); }
            set { BackingStore?.Set("username", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails"/> and sets the default values.
        /// </summary>
        public MyAccountDetails()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "achievements_points", n => { AchievementsPoints = n.GetIntValue(); } },
                { "badges", n => { Badges = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges>(global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges.CreateFromDiscriminatorValue); } },
                { "ban_reason", n => { BanReason = n.GetStringValue(); } },
                { "banned", n => { Banned = n.GetBoolValue(); } },
                { "email", n => { Email = n.GetStringValue(); } },
                { "gems", n => { Gems = n.GetIntValue(); } },
                { "status", n => { Status = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AccountStatus>(); } },
                { "subscribed", n => { Subscribed = n.GetBoolValue(); } },
                { "username", n => { Username = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("achievements_points", AchievementsPoints);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges>("badges", Badges);
            writer.WriteBoolValue("banned", Banned);
            writer.WriteStringValue("ban_reason", BanReason);
            writer.WriteStringValue("email", Email);
            writer.WriteIntValue("gems", Gems);
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.AccountStatus>("status", Status);
            writer.WriteBoolValue("subscribed", Subscribed);
            writer.WriteStringValue("username", Username);
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails_badgesMember1"/>, <see cref="Null"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class MyAccountDetails_badges : IBackedModel, IComposedTypeWrapper, IParsable
        {
            /// <summary>Stores model information.</summary>
            public IBackingStore BackingStore { get; private set; }
            /// <summary>Composed type representation for type <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails_badgesMember1"/></summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails_badgesMember1? MyAccountDetailsBadgesMember1
            {
                get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails_badgesMember1?>("MyAccountDetails_badgesMember1"); }
                set { BackingStore?.Set("MyAccountDetails_badgesMember1", value); }
            }
#nullable restore
#else
            public global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails_badgesMember1 MyAccountDetailsBadgesMember1
            {
                get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails_badgesMember1>("MyAccountDetails_badgesMember1"); }
                set { BackingStore?.Set("MyAccountDetails_badgesMember1", value); }
            }
#endif
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
            /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges"/> and sets the default values.
            /// </summary>
            public MyAccountDetails_badges()
            {
                BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails.MyAccountDetails_badges();
                if(parseNode.GetObjectValue<Null>(Null.CreateFromDiscriminatorValue) is Null nullValue)
                {
                    result.Null = nullValue;
                }
                else {
                    result.MyAccountDetailsBadgesMember1 = new global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails_badgesMember1();
                }
                return result;
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
            public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
            {
                if(MyAccountDetailsBadgesMember1 != null)
                {
                    return ParseNodeHelper.MergeDeserializersForIntersectionWrapper(MyAccountDetailsBadgesMember1);
                }
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
                else {
                    writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.MyAccountDetails_badgesMember1>(null, MyAccountDetailsBadgesMember1);
                }
            }
        }
    }
}
#pragma warning restore CS0618
