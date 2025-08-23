using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeNoOrdersException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeNoOrders;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeNoOrdersException() : base("Ge no orders")
    {
    }

    public GeNoOrdersException(string message) : base(message)
    {
    }

    public GeNoOrdersException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeNoOrdersException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
