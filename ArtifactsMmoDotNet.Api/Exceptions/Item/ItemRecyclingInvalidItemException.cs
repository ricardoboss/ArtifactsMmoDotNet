using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Item;

public class ItemRecyclingInvalidItemException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.ItemRecyclingInvalidItem;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public ItemRecyclingInvalidItemException() : base("Item recycling invalid item")
    {
    }

    public ItemRecyclingInvalidItemException(string message) : base(message)
    {
    }

    public ItemRecyclingInvalidItemException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static ItemRecyclingInvalidItemException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
