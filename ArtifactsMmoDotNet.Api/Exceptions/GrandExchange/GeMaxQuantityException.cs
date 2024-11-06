using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeMaxQuantityException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeMaxQuantity;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeMaxQuantityException() : base("Ge max quantity")
    {
    }

    public GeMaxQuantityException(string message) : base(message)
    {
    }

    public GeMaxQuantityException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeMaxQuantityException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new GeMaxQuantityException();
    }
}
