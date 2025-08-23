using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Item;

public class ItemInvalidConsumableException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.ItemInvalidConsumable;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public ItemInvalidConsumableException() : base("Item invalid consumable")
    {
    }

    public ItemInvalidConsumableException(string message) : base(message)
    {
    }

    public ItemInvalidConsumableException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static ItemInvalidConsumableException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
