using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterTooManyItemsTaskException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterTooManyItemsTask;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterTooManyItemsTaskException() : base("Character too many items task")
    {
    }

    public CharacterTooManyItemsTaskException(string message) : base(message)
    {
    }

    public CharacterTooManyItemsTaskException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterTooManyItemsTaskException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
