// <auto-generated/>
#pragma warning disable CS0618
using ArtifactsMmoDotNet.Api.Generated.Accounts.Create;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.Accounts
{
    /// <summary>
    /// Builds and executes requests for operations under \accounts
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class AccountsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The create property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.Accounts.Create.CreateRequestBuilder Create
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.Accounts.Create.CreateRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Accounts.AccountsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AccountsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/accounts", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Accounts.AccountsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public AccountsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/accounts", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
