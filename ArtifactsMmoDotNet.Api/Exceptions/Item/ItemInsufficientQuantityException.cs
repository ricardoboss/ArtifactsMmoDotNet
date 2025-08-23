using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Item;

public class ItemInsufficientQuantityException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.ItemInsufficientQuantity;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public ItemInsufficientQuantityException() : base("Item insufficient quantity")
    {
    }

    public ItemInsufficientQuantityException(string message) : base(message)
    {
    }

    public ItemInsufficientQuantityException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static ItemInsufficientQuantityException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
