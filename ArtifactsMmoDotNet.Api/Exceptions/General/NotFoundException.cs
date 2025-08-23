using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.General;

public class NotFoundException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.NotFound;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public NotFoundException() : base("Not found")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static NotFoundException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
