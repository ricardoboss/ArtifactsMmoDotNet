// <auto-generated/>
#pragma warning disable CS0618
using ArtifactsMmoDotNet.Api.Generated.Characters.Create;
using ArtifactsMmoDotNet.Api.Generated.Characters.Delete;
using ArtifactsMmoDotNet.Api.Generated.Characters.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
        public CharactersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/characters", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ArtifactsMmoDotNet.Api.Generated.Characters.CharactersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CharactersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/characters", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
