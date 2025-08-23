using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Map;

public class MapContentNotFoundException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.MapContentNotFound;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public MapContentNotFoundException() : base("Map content not found")
    {
    }

    public MapContentNotFoundException(string message) : base(message)
    {
    }

    public MapContentNotFoundException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static MapContentNotFoundException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
