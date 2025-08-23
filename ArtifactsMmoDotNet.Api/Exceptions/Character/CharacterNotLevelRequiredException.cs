using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterNotLevelRequiredException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterNotLevelRequired;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterNotLevelRequiredException() : base("Character not level required")
    {
    }

    public CharacterNotLevelRequiredException(string message) : base(message)
    {
    }

    public CharacterNotLevelRequiredException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static CharacterNotLevelRequiredException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
