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
    public partial class DataPage_ActiveEventSchema_ : IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema>? Data
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema>?>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#nullable restore
#else
        public List<global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema> Data
        {
            get { return BackingStore?.Get<List<global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema>>("data"); }
            set { BackingStore?.Set("data", value); }
        }
#endif
        /// <summary>The page property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page? Page
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page?>("page"); }
            set { BackingStore?.Set("page", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page Page
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page>("page"); }
            set { BackingStore?.Set("page", value); }
        }
#endif
        /// <summary>The pages property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages? Pages
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages?>("pages"); }
            set { BackingStore?.Set("pages", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages Pages
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages>("pages"); }
            set { BackingStore?.Set("pages", value); }
        }
#endif
        /// <summary>The size property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size? Size
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size?>("size"); }
            set { BackingStore?.Set("size", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size Size
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size>("size"); }
            set { BackingStore?.Set("size", value); }
        }
#endif
        /// <summary>The total property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total? Total
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total?>("total"); }
            set { BackingStore?.Set("total", value); }
        }
#nullable restore
#else
        public global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total Total
        {
            get { return BackingStore?.Get<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total>("total"); }
            set { BackingStore?.Set("total", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_"/> and sets the default values.
        /// </summary>
        public DataPage_ActiveEventSchema_()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_ CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema>(global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema.CreateFromDiscriminatorValue)?.AsList(); } },
                { "page", n => { Page = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page>(global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page.CreateFromDiscriminatorValue); } },
                { "pages", n => { Pages = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages>(global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages.CreateFromDiscriminatorValue); } },
                { "size", n => { Size = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size>(global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size.CreateFromDiscriminatorValue); } },
                { "total", n => { Total = n.GetObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total>(global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::ArtifactsMmoDotNet.Api.Generated.Models.ActiveEventSchema>("data", Data);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page>("page", Page);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages>("pages", Pages);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size>("size", Size);
            writer.WriteObjectValue<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total>("total", Total);
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="int"/>, <see cref="Null"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class DataPage_ActiveEventSchema__page : IBackedModel, IComposedTypeWrapper, IParsable
        {
            /// <summary>Stores model information.</summary>
            public IBackingStore BackingStore { get; private set; }
            /// <summary>Composed type representation for type <see cref="int"/></summary>
            public int? Integer
            {
                get { return BackingStore?.Get<int?>("integer"); }
                set { BackingStore?.Set("integer", value); }
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
            /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page"/> and sets the default values.
            /// </summary>
            public DataPage_ActiveEventSchema__page()
            {
                BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__page();
                if(parseNode.GetIntValue() is int integerValue)
                {
                    result.Integer = integerValue;
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
                if(Integer != null)
                {
                    writer.WriteIntValue(null, Integer);
                }
                else if(Null != null)
                {
                    writer.WriteObjectValue<Null>(null, Null);
                }
            }
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="int"/>, <see cref="Null"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class DataPage_ActiveEventSchema__pages : IBackedModel, IComposedTypeWrapper, IParsable
        {
            /// <summary>Stores model information.</summary>
            public IBackingStore BackingStore { get; private set; }
            /// <summary>Composed type representation for type <see cref="int"/></summary>
            public int? Integer
            {
                get { return BackingStore?.Get<int?>("integer"); }
                set { BackingStore?.Set("integer", value); }
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
            /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages"/> and sets the default values.
            /// </summary>
            public DataPage_ActiveEventSchema__pages()
            {
                BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__pages();
                if(parseNode.GetIntValue() is int integerValue)
                {
                    result.Integer = integerValue;
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
                if(Integer != null)
                {
                    writer.WriteIntValue(null, Integer);
                }
                else if(Null != null)
                {
                    writer.WriteObjectValue<Null>(null, Null);
                }
            }
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="int"/>, <see cref="Null"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class DataPage_ActiveEventSchema__size : IBackedModel, IComposedTypeWrapper, IParsable
        {
            /// <summary>Stores model information.</summary>
            public IBackingStore BackingStore { get; private set; }
            /// <summary>Composed type representation for type <see cref="int"/></summary>
            public int? Integer
            {
                get { return BackingStore?.Get<int?>("integer"); }
                set { BackingStore?.Set("integer", value); }
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
            /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size"/> and sets the default values.
            /// </summary>
            public DataPage_ActiveEventSchema__size()
            {
                BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__size();
                if(parseNode.GetIntValue() is int integerValue)
                {
                    result.Integer = integerValue;
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
                if(Integer != null)
                {
                    writer.WriteIntValue(null, Integer);
                }
                else if(Null != null)
                {
                    writer.WriteObjectValue<Null>(null, Null);
                }
            }
        }
        /// <summary>
        /// Composed type wrapper for classes <see cref="int"/>, <see cref="Null"/>
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class DataPage_ActiveEventSchema__total : IBackedModel, IComposedTypeWrapper, IParsable
        {
            /// <summary>Stores model information.</summary>
            public IBackingStore BackingStore { get; private set; }
            /// <summary>Composed type representation for type <see cref="int"/></summary>
            public int? Integer
            {
                get { return BackingStore?.Get<int?>("integer"); }
                set { BackingStore?.Set("integer", value); }
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
            /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total"/> and sets the default values.
            /// </summary>
            public DataPage_ActiveEventSchema__total()
            {
                BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            }
            /// <summary>
            /// Creates a new instance of the appropriate class based on discriminator value
            /// </summary>
            /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total"/></returns>
            /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
            public static global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total CreateFromDiscriminatorValue(IParseNode parseNode)
            {
                _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
                var result = new global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_ActiveEventSchema_.DataPage_ActiveEventSchema__total();
                if(parseNode.GetIntValue() is int integerValue)
                {
                    result.Integer = integerValue;
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
                if(Integer != null)
                {
                    writer.WriteIntValue(null, Integer);
                }
                else if(Null != null)
                {
                    writer.WriteObjectValue<Null>(null, Null);
                }
            }
        }
    }
}
#pragma warning restore CS0618
