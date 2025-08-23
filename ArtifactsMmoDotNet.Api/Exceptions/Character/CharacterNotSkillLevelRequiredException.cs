using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterNotSkillLevelRequiredException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterNotSkillLevelRequired;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterNotSkillLevelRequiredException() : base("Character not skill level required")
    {
    }

    public CharacterNotSkillLevelRequiredException(string message) : base(message)
    {
    }

    public CharacterNotSkillLevelRequiredException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static CharacterNotSkillLevelRequiredException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
