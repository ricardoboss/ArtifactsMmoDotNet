using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Account;

public class EmailAlreadyUsedException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.EmailAlreadyUsed;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public EmailAlreadyUsedException() : base("Email already used")
    {
    }

    public EmailAlreadyUsedException(string message) : base(message)
    {
    }

    public EmailAlreadyUsedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static EmailAlreadyUsedException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new EmailAlreadyUsedException();
    }
}
