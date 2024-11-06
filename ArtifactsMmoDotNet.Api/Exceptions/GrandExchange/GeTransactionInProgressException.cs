using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeTransactionInProgressException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeTransactionInProgress;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeTransactionInProgressException() : base("Ge transaction in progress")
    {
    }

    public GeTransactionInProgressException(string message) : base(message)
    {
    }

    public GeTransactionInProgressException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static GeTransactionInProgressException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new GeTransactionInProgressException();
    }
}
