// <auto-generated/>
#pragma warning disable CS0618
using ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Cancel;
using ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Complete;
using ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Exchange;
using ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.New;
using ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Trade;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace
{
    /// <summary>
    /// Builds and executes requests for operations under \my\{name}\action\task
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.18.0")]
    public partial class TaskRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The cancel property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Cancel.CancelRequestBuilder Cancel
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Cancel.CancelRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The complete property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Complete.CompleteRequestBuilder Complete
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Complete.CompleteRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The exchange property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Exchange.ExchangeRequestBuilder Exchange
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Exchange.ExchangeRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The new property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.New.NewRequestBuilder New
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.New.NewRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The trade property</summary>
        public global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Trade.TradeRequestBuilder Trade
        {
            get => new global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.Trade.TradeRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.TaskRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public TaskRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/task", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.My.Item.ActionNamespace.TaskNamespace.TaskRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public TaskRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/{name}/action/task", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
