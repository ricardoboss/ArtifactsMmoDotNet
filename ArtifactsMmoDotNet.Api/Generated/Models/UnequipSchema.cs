// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.16.0")]
    #pragma warning disable CS1591
    public partial class UnequipSchema : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Item slot.</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Models.UnequipSchema_slot? Slot
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.UnequipSchema_slot?>("slot"); }
            set { BackingStore?.Set("slot", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.UnequipSchema"/> and sets the default values.
        /// </summary>
        public UnequipSchema()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.UnequipSchema"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.UnequipSchema CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.UnequipSchema();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "slot", n => { Slot = n.GetEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.UnequipSchema_slot>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<global::ArtifactsMmoDotNet.Api.Generated.Models.UnequipSchema_slot>("slot", Slot);
        }
    }
}
