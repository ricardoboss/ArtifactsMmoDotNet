using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeSameAccountException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeSameAccount;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeSameAccountException() : base("Ge same account")
    {
    }

    public GeSameAccountException(string message) : base(message)
    {
    }

    public GeSameAccountException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeSameAccountException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
