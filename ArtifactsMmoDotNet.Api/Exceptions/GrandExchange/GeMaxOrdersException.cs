using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeMaxOrdersException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeMaxOrders;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeMaxOrdersException() : base("Ge max orders")
    {
    }

    public GeMaxOrdersException(string message) : base(message)
    {
    }

    public GeMaxOrdersException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeMaxOrdersException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
