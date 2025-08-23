using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterItemAlreadyEquippedException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterItemAlreadyEquipped;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterItemAlreadyEquippedException() : base("Character item already equipped")
    {
    }

    public CharacterItemAlreadyEquippedException(string message) : base(message)
    {
    }

    public CharacterItemAlreadyEquippedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterItemAlreadyEquippedException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
