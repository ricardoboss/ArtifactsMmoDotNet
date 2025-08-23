using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Account;

public class CurrentPasswordInvalidException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CurrentPasswordInvalid;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CurrentPasswordInvalidException() : base("Current password invalid")
    {
    }

    public CurrentPasswordInvalidException(string message) : base(message)
    {
    }

    public CurrentPasswordInvalidException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CurrentPasswordInvalidException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
