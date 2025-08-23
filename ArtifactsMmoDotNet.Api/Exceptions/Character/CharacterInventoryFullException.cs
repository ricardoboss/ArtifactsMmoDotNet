using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterInventoryFullException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterInventoryFull;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterInventoryFullException() : base("Character inventory full")
    {
    }

    public CharacterInventoryFullException(string message) : base(message)
    {
    }

    public CharacterInventoryFullException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static CharacterInventoryFullException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
