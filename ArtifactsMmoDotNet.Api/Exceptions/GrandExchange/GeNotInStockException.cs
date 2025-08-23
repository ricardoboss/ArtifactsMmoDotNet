using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeNotInStockException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeNotInStock;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeNotInStockException() : base("Ge not in stock")
    {
    }

    public GeNotInStockException(string message) : base(message)
    {
    }

    public GeNotInStockException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeNotInStockException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
