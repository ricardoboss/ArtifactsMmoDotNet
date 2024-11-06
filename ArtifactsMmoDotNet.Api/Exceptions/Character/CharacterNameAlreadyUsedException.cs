using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterNameAlreadyUsedException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterNameAlreadyUsed;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterNameAlreadyUsedException() : base("Character name already used")
    {
    }

    public CharacterNameAlreadyUsedException(string message) : base(message)
    {
    }

    public CharacterNameAlreadyUsedException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static CharacterNameAlreadyUsedException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new CharacterNameAlreadyUsedException();
    }
}
