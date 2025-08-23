using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Account;

public class SamePasswordException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.SamePassword;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public SamePasswordException() : base("Same password")
    {
    }

    public SamePasswordException(string message) : base(message)
    {
    }

    public SamePasswordException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static SamePasswordException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
