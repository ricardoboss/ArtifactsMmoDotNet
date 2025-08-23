using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Account;

public class TokenInvalidException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.TokenInvalid;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public TokenInvalidException() : base("Token invalid")
    {
    }

    public TokenInvalidException(string message) : base(message)
    {
    }

    public TokenInvalidException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static TokenInvalidException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
