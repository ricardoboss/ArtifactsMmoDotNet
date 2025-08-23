using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Character;

public class MaxCharactersReachedException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.MaxCharactersReached;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public MaxCharactersReachedException() : base("Max characters reached")
    {
    }

    public MaxCharactersReachedException(string message) : base(message)
    {
    }

    public MaxCharactersReachedException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static MaxCharactersReachedException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
