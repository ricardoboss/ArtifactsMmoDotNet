using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterTaskNotCompletedException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterTaskNotCompleted;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterTaskNotCompletedException() : base("Character task not completed")
    {
    }

    public CharacterTaskNotCompletedException(string message) : base(message)
    {
    }

    public CharacterTaskNotCompletedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterTaskNotCompletedException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
