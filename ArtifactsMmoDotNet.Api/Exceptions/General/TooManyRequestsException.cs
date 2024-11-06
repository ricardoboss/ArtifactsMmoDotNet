using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.General;

public class TooManyRequestsException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.TooManyRequests;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public TooManyRequestsException() : base("Too many requests")
    {
    }

    public TooManyRequestsException(string message) : base(message)
    {
    }

    public TooManyRequestsException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static TooManyRequestsException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new TooManyRequestsException();
    }
}
