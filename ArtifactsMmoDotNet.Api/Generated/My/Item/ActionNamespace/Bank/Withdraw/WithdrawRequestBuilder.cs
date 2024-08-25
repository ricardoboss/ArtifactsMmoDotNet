// <auto-generated/>
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw.Gold;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw
{
    /// <summary>
    /// Builds and executes requests for operations under \my\{name}\action\bank\withdraw
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.16.0")]
    public partial class WithdrawRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The gold property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw.Gold.GoldRequestBuilder Gold
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw.Gold.GoldRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw.WithdrawRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithdrawRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/bank/withdraw", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw.WithdrawRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithdrawRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/bank/withdraw", rawUrl)
        {
        }
        /// <summary>
        /// Take an item from your bank and put it in the character&apos;s inventory.
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.Models.BankItemTransactionResponseSchema"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::ArtifactsMmoDotNet.Api.Generated.Models.BankItemTransactionResponseSchema?> PostAsync(global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::ArtifactsMmoDotNet.Api.Generated.Models.BankItemTransactionResponseSchema> PostAsync(global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            return await RequestAdapter.SendAsync<global::ArtifactsMmoDotNet.Api.Generated.Models.BankItemTransactionResponseSchema>(requestInfo, global::ArtifactsMmoDotNet.Api.Generated.Models.BankItemTransactionResponseSchema.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Take an item from your bank and put it in the character&apos;s inventory.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::ArtifactsMmoDotNet.Api.Generated.Models.SimpleItemSchema body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw.WithdrawRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw.WithdrawRequestBuilder WithUrl(string rawUrl)
        {
            return new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.Bank.Withdraw.WithdrawRequestBuilder(rawUrl, RequestAdapter);
        }
    }
}
