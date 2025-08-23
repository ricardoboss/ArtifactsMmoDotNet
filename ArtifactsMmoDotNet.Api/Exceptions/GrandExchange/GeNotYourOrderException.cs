using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeNotYourOrderException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeNotYourOrder;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeNotYourOrderException() : base("Ge not your order")
    {
    }

    public GeNotYourOrderException(string message) : base(message)
    {
    }

    public GeNotYourOrderException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeNotYourOrderException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
