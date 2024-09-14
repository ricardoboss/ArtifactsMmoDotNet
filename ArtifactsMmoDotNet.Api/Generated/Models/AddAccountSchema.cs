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
    public partial class AddAccountSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Your email.</summary>
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
        /// <summary>Your password.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Password
        {
            get { return BackingStore?.Get<string?>("password"); }
            set { BackingStore?.Set("password", value); }
        }
#nullable restore
#else
        public string Password
        {
            get { return BackingStore?.Get<string>("password"); }
            set { BackingStore?.Set("password", value); }
        }
#endif
        /// <summary>Your desired username.</summary>
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
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AddAccountSchema"/> and sets the default values.
        /// </summary>
        public AddAccountSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.AddAccountSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.AddAccountSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.AddAccountSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "email", n => { Email = n.GetStringValue(); } },
                { "password", n => { Password = n.GetStringValue(); } },
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
            writer.WriteStringValue("email", Email);
            writer.WriteStringValue("password", Password);
            writer.WriteStringValue("username", Username);
        }
    }
}
#pragma warning restore CS0618
