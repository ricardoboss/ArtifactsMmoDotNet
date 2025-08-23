using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Account;

public class TokenGenerationFailException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.TokenGenerationFail;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public TokenGenerationFailException() : base("Token generation fail")
    {
    }

    public TokenGenerationFailException(string message) : base(message)
    {
    }

    public TokenGenerationFailException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static TokenGenerationFailException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
