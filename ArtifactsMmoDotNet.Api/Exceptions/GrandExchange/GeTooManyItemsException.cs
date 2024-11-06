using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.GrandExchange;

public class GeTooManyItemsException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.GeTooManyItems;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public GeTooManyItemsException() : base("Ge too many items")
    {
    }

    public GeTooManyItemsException(string message) : base(message)
    {
    }

    public GeTooManyItemsException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static GeTooManyItemsException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new GeTooManyItemsException();
    }
}
