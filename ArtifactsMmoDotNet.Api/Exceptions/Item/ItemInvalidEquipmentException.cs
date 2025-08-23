using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Item;

public class ItemInvalidEquipmentException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.ItemInvalidEquipment;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public ItemInvalidEquipmentException() : base("Item invalid equipment")
    {
    }

    public ItemInvalidEquipmentException(string message) : base(message)
    {
    }

    public ItemInvalidEquipmentException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static ItemInvalidEquipmentException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
