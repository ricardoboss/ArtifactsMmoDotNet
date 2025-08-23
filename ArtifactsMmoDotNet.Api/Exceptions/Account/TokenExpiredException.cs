using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Account;

public class TokenExpiredException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.TokenExpired;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public TokenExpiredException() : base("Token expired")
    {
    }

    public TokenExpiredException(string message) : base(message)
    {
    }

    public TokenExpiredException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static TokenExpiredException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
