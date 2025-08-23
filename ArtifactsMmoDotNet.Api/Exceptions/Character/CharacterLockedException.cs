using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterLockedException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterLocked;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterLockedException() : base("Character locked")
    {
    }

    public CharacterLockedException(string message) : base(message)
    {
    }

    public CharacterLockedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterLockedException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
