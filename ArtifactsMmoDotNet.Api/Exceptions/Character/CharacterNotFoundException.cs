using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterNotFoundException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterNotFound;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterNotFoundException() : base("Character not found")
    {
    }

    public CharacterNotFoundException(string message) : base(message)
    {
    }

    public CharacterNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterNotFoundException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
