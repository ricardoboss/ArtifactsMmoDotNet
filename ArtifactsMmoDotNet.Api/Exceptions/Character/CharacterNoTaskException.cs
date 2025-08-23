using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class CharacterNoTaskException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.CharacterNoTask;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public CharacterNoTaskException() : base("Character no task")
    {
    }

    public CharacterNoTaskException(string message) : base(message)
    {
    }

    public CharacterNoTaskException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static CharacterNoTaskException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
