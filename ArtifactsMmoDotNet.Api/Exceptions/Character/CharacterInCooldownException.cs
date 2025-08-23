using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterInCooldownException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterInCooldown;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterInCooldownException() : base("Character in cooldown")
    {
    }

    public CharacterInCooldownException(string message) : base(message)
    {
    }

    public CharacterInCooldownException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterInCooldownException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
