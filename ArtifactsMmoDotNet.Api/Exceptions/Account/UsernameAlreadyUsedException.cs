using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Account;

public class UsernameAlreadyUsedException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.UsernameAlreadyUsed;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public UsernameAlreadyUsedException() : base("Username already used")
    {
    }

    public UsernameAlreadyUsedException(string message) : base(message)
    {
    }

    public UsernameAlreadyUsedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static UsernameAlreadyUsedException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new UsernameAlreadyUsedException();
    }
}
