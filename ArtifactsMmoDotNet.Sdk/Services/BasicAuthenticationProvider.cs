using System.Text;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace ArtifactsMmoDotNet.Sdk.Services;

public sealed class BasicAuthenticationProvider(string username, string password) : IAuthenticationProvider
{
    private readonly Lazy<string> lazyBasicAuthCredentials = new Lazy<string>(() =>
    {
        var bytes = Encoding.UTF8.GetBytes($"{username}:{password}");

        return Convert.ToBase64String(bytes);
    });

    private string basicAuthCredentials => lazyBasicAuthCredentials.Value;

    public Task AuthenticateRequestAsync(
        RequestInformation request,
        Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = default
    )
    {
        request.Headers.Add("Authorization", $"Basic {basicAuthCredentials}");

        return Task.CompletedTask;
    }
}
