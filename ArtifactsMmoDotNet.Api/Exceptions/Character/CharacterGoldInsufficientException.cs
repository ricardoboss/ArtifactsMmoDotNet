using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterGoldInsufficientException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterGoldInsufficient;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterGoldInsufficientException() : base("Character gold insufficient")
    {
    }

    public CharacterGoldInsufficientException(string message) : base(message)
    {
    }

    public CharacterGoldInsufficientException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterGoldInsufficientException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new CharacterGoldInsufficientException();
    }
}
