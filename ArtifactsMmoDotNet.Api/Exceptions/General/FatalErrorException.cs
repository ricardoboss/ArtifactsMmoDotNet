using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.General;

public class FatalErrorException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.FatalError;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public FatalErrorException() : base("Fatal error")
    {
    }

    public FatalErrorException(string message) : base(message)
    {
    }

    public FatalErrorException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static FatalErrorException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new FatalErrorException();
    }
}
