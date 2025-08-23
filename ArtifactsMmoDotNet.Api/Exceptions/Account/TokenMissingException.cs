using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Account;

public class TokenMissingException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.TokenMissing;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public TokenMissingException() : base("Token missing")
    {
    }

    public TokenMissingException(string message) : base(message)
    {
    }

    public TokenMissingException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static TokenMissingException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
