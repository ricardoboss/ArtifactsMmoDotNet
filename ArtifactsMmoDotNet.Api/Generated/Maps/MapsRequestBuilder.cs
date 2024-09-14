// <auto-generated/>
#pragma warning disable CS0618
using ArtifactsMmoDotNet.Api.Generated.Maps.Item;
using ArtifactsMmoDotNet.Api.Generated.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.Maps
{
    /// <summary>
    /// Builds and executes requests for operations under \maps
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class MapsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the ArtifactsMmoDotNet.Api.Generated.maps.item collection</summary>
        /// <param name="position">The position x of the map.</param>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Maps.Item.WithXItemRequestBuilder"/></returns>
        public global::ArtifactsMmoDotNet.Api.Generated.Maps.Item.WithXItemRequestBuilder this[int position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("x", position);
                return new global::ArtifactsMmoDotNet.Api.Generated.Maps.Item.WithXItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MapsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/maps{?content_code*,content_type*,page*,size*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MapsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/maps{?content_code*,content_type*,page*,size*}", rawUrl)
        {
        }
        /// <summary>
        /// Fetch maps details.
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_MapSchema_"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_MapSchema_?> GetAsync(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder.MapsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_MapSchema_> GetAsync(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder.MapsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_MapSchema_>(requestInfo, global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_MapSchema_.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Fetch maps details.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder.MapsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder.MapsRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::ArtifactsMmoDotNet.Api.Generated.Maps.MapsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Fetch maps details.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class MapsRequestBuilderGetQueryParameters 
        {
            /// <summary>Content code on the map.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("content_code")]
            public string? ContentCode { get; set; }
#nullable restore
#else
            [QueryParameter("content_code")]
            public string ContentCode { get; set; }
#endif
            /// <summary>Type of content on the map.</summary>
            [QueryParameter("content_type")]
            public global::ArtifactsMmoDotNet.Api.Generated.Maps.GetContent_typeQueryParameterType? ContentType { get; set; }
            /// <summary>Page number</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>Page size</summary>
            [QueryParameter("size")]
            public int? Size { get; set; }
        }
    }
}
#pragma warning restore CS0618
