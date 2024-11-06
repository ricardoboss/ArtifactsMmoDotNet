using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterMaximumUtilitiesEquippedException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterMaximumUtilitiesEquipped;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterMaximumUtilitiesEquippedException() : base("Character maximum utilities equipped")
    {
    }

    public CharacterMaximumUtilitiesEquippedException(string message) : base(message)
    {
    }

    public CharacterMaximumUtilitiesEquippedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterMaximumUtilitiesEquippedException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new CharacterMaximumUtilitiesEquippedException();
    }
}
