// <auto-generated/>
#pragma warning disable CS0618
using ArtifactsMmoDotNet.Api.Generated.Characters.Create;
using ArtifactsMmoDotNet.Api.Generated.Characters.Delete;
using ArtifactsMmoDotNet.Api.Generated.Characters.Item;
using ArtifactsMmoDotNet.Api.Generated.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.Characters
{
    /// <summary>
    /// Builds and executes requests for operations under \characters
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class CharactersRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The create property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Characters.Create.CreateRequestBuilder Create
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.Characters.Create.CreateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The deletePath property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Characters.Delete.DeleteRequestBuilder DeletePath
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.Characters.Delete.DeleteRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Gets an item from the ArtifactsMmoDotNet.Api.Generated.characters.item collection</summary>
        /// <param name="position">The character name.</param>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Characters.Item.WithNameItemRequestBuilder"/></returns>
        public global::ArtifactsMmoDotNet.Api.Generated.Characters.Item.WithNameItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("name", position);
                return new global::ArtifactsMmoDotNet.Api.Generated.Characters.Item.WithNameItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CharactersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/characters{?page*,size*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CharactersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/characters{?page*,size*}", rawUrl)
        {
        }
        /// <summary>
        /// Fetch characters details.
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_CharacterSchema_"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_CharacterSchema_?> GetAsync(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder.CharactersRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_CharacterSchema_> GetAsync(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder.CharactersRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_CharacterSchema_>(requestInfo, global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_CharacterSchema_.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Fetch characters details.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder.CharactersRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder.CharactersRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder WithUrl(string rawUrl)
        {
            return new global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Fetch characters details.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class CharactersRequestBuilderGetQueryParameters 
        {
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
