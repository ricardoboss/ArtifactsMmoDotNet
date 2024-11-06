using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Item;

public class MissingItemException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.MissingItem;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public MissingItemException() : base("Missing item")
    {
    }

    public MissingItemException(string message) : base(message)
    {
    }

    public MissingItemException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static MissingItemException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new MissingItemException();
    }
}
