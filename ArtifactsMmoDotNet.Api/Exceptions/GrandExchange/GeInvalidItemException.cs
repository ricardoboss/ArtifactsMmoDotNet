using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeInvalidItemException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeInvalidItem;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeInvalidItemException() : base("Ge invalid item")
    {
    }

    public GeInvalidItemException(string message) : base(message)
    {
    }

    public GeInvalidItemException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeInvalidItemException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
