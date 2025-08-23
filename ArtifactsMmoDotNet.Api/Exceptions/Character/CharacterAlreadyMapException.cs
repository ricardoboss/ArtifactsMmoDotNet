using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterAlreadyMapException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterAlreadyMap;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterAlreadyMapException() : base("Character already map")
    {
    }

    public CharacterAlreadyMapException(string message) : base(message)
    {
    }

    public CharacterAlreadyMapException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterAlreadyMapException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
