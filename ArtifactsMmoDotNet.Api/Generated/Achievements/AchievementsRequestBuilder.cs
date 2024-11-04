// <auto-generated/>
#pragma warning disable CS0618
using ArtifactsMmoDotNet.Api.Generated.Achievements.Item;
using ArtifactsMmoDotNet.Api.Generated.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.Achievements
{
    /// <summary>
    /// Builds and executes requests for operations under \achievements
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class AchievementsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the ArtifactsMmoDotNet.Api.Generated.achievements.item collection</summary>
        /// <param name="position">The code of the achievement.</param>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Achievements.Item.WithCodeItemRequestBuilder"/></returns>
        public global::ArtifactsMmoDotNet.Api.Generated.Achievements.Item.WithCodeItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("code", position);
                return new global::ArtifactsMmoDotNet.Api.Generated.Achievements.Item.WithCodeItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AchievementsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/achievements{?page*,size*,type*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AchievementsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/achievements{?page*,size*,type*}", rawUrl)
        {
        }
        /// <summary>
        /// List of all achievements.
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_AchievementSchema_"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_AchievementSchema_?> GetAsync(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder.AchievementsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_AchievementSchema_> GetAsync(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder.AchievementsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_AchievementSchema_>(requestInfo, global::ArtifactsMmoDotNet.Api.Generated.Models.DataPage_AchievementSchema_.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// List of all achievements.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder.AchievementsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder.AchievementsRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::ArtifactsMmoDotNet.Api.Generated.Achievements.AchievementsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// List of all achievements.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
        public partial class AchievementsRequestBuilderGetQueryParameters 
        {
            /// <summary>Page number</summary>
            [QueryParameter("page")]
            public int? Page { get; set; }
            /// <summary>Page size</summary>
            [QueryParameter("size")]
            public int? Size { get; set; }
            /// <summary>Type of achievements.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("type")]
            public string? Type { get; set; }
#nullable restore
#else
            [QueryParameter("type")]
            public string Type { get; set; }
#endif
        }
    }
}
#pragma warning restore CS0618
