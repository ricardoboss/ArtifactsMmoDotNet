using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterAlreadyTaskException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterAlreadyTask;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterAlreadyTaskException() : base("Character already task")
    {
    }

    public CharacterAlreadyTaskException(string message) : base(message)
    {
    }

    public CharacterAlreadyTaskException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterAlreadyTaskException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
