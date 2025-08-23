using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.General;

public class InvalidPayloadException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.InvalidPayload;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public InvalidPayloadException() : base("Invalid payload")
    {
    }

    public InvalidPayloadException(string message) : base(message)
    {
    }

    public InvalidPayloadException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static InvalidPayloadException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
