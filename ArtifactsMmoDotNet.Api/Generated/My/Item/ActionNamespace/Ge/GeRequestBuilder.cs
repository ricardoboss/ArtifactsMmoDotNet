// <auto-generated/>
#pragma warning disable CS0618
using ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge.Buy;
using ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge.Sell;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge
{
    /// <summary>
    /// Builds and executes requests for operations under \my\{name}\action\ge
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class GeRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The buy property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge.Buy.BuyRequestBuilder Buy
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge.Buy.BuyRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The sell property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge.Sell.SellRequestBuilder Sell
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge.Sell.SellRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge.GeRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GeRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/ge", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Ge.GeRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GeRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/ge", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
