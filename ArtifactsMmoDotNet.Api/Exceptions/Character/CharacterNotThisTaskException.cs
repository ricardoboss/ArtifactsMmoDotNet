using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterNotThisTaskException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterNotThisTask;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterNotThisTaskException() : base("Character not this task")
    {
    }

    public CharacterNotThisTaskException(string message) : base(message)
    {
    }

    public CharacterNotThisTaskException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterNotThisTaskException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
