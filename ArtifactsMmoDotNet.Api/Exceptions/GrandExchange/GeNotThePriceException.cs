using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeNotThePriceException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeNotThePrice;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeNotThePriceException() : base("Ge not the price")
    {
    }

    public GeNotThePriceException(string message) : base(message)
    {
    }

    public GeNotThePriceException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeNotThePriceException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
