using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Map;

public class MapNotFoundException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.MapNotFound;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public MapNotFoundException() : base("Map not found")
    {
    }

    public MapNotFoundException(string message) : base(message)
    {
    }

    public MapNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static MapNotFoundException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
