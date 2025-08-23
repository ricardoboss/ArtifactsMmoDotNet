using System.Text;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace ArtifactsMmoDotNet.Sdk.Services;

public sealed class BasicAuthenticationProvider(string username, string password) : IAuthenticationProvider
{
    private readonly Lazy<string> lazyBasicAuthCredentials = new(() =>
    {
        var bytes = Encoding.UTF8.GetBytes($"{username}:{password}");

        return Convert.ToBase64String(bytes);
    });

    private string BasicAuthCredentials => lazyBasicAuthCredentials.Value;

    public Task AuthenticateRequestAsync(
        RequestInformation request,
        Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(request);

        request.Headers.Add("Authorization", $"Basic {BasicAuthCredentials}");

        return Task.CompletedTask;
    }
}
