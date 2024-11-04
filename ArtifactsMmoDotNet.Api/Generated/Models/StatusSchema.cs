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
    public partial class StatusSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Server announcements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.AnnouncementSchema>? Announcements
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.AnnouncementSchema>?>("announcements"); }
            set { BackingStore?.Set("announcements", value); }
        }
#nullable restore
#else
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.AnnouncementSchema> Announcements
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.AnnouncementSchema>>("announcements"); }
            set { BackingStore?.Set("announcements", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Characters online.</summary>
        public int? CharactersOnline
        {
            get { return BackingStore?.Get<int?>("characters_online"); }
            set { BackingStore?.Set("characters_online", value); }
        }
        /// <summary>Last server wipe.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LastWipe
        {
            get { return BackingStore?.Get<string?>("last_wipe"); }
            set { BackingStore?.Set("last_wipe", value); }
        }
#nullable restore
#else
        public string LastWipe
        {
            get { return BackingStore?.Get<string>("last_wipe"); }
            set { BackingStore?.Set("last_wipe", value); }
        }
#endif
        /// <summary>Maximum level.</summary>
        public int? MaxLevel
        {
            get { return BackingStore?.Get<int?>("max_level"); }
            set { BackingStore?.Set("max_level", value); }
        }
        /// <summary>Next server wipe.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? NextWipe
        {
            get { return BackingStore?.Get<string?>("next_wipe"); }
            set { BackingStore?.Set("next_wipe", value); }
        }
#nullable restore
#else
        public string NextWipe
        {
            get { return BackingStore?.Get<string>("next_wipe"); }
            set { BackingStore?.Set("next_wipe", value); }
        }
#endif
        /// <summary>Server time.</summary>
        public DateTimeOffset? ServerTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("server_time"); }
            set { BackingStore?.Set("server_time", value); }
        }
        /// <summary>Server status</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Status
        {
            get { return BackingStore?.Get<string?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
#nullable restore
#else
        public string Status
        {
            get { return BackingStore?.Get<string>("status"); }
            set { BackingStore?.Set("status", value); }
        }
#endif
        /// <summary>Game version.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Version
        {
            get { return BackingStore?.Get<string?>("version"); }
            set { BackingStore?.Set("version", value); }
        }
#nullable restore
#else
        public string Version
        {
            get { return BackingStore?.Get<string>("version"); }
            set { BackingStore?.Set("version", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.StatusSchema"/> and sets the default values.
        /// </summary>
        public StatusSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.StatusSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.StatusSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.StatusSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "announcements", n => { Announcements = n.GetCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.AnnouncementSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.AnnouncementSchema.CreateFromDiscriminatorValue)?.AsList(); } },
                { "characters_online", n => { CharactersOnline = n.GetIntValue(); } },
                { "last_wipe", n => { LastWipe = n.GetStringValue(); } },
                { "max_level", n => { MaxLevel = n.GetIntValue(); } },
                { "next_wipe", n => { NextWipe = n.GetStringValue(); } },
                { "server_time", n => { ServerTime = n.GetDateTimeOffsetValue(); } },
                { "status", n => { Status = n.GetStringValue(); } },
                { "version", n => { Version = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.AnnouncementSchema>("announcements", Announcements);
            writer.WriteIntValue("characters_online", CharactersOnline);
            writer.WriteStringValue("last_wipe", LastWipe);
            writer.WriteIntValue("max_level", MaxLevel);
            writer.WriteStringValue("next_wipe", NextWipe);
            writer.WriteDateTimeOffsetValue("server_time", ServerTime);
            writer.WriteStringValue("status", Status);
            writer.WriteStringValue("version", Version);
        }
    }
}
#pragma warning restore CS0618
