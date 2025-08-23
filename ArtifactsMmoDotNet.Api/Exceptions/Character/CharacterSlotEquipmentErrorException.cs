using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterSlotEquipmentErrorException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterSlotEquipmentError;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterSlotEquipmentErrorException() : base("Character slot equipment error")
    {
    }

    public CharacterSlotEquipmentErrorException(string message) : base(message)
    {
    }

    public CharacterSlotEquipmentErrorException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static CharacterSlotEquipmentErrorException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
