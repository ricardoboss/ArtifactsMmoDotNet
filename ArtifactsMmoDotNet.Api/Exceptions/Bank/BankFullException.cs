using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Bank;

public class BankFullException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.BankFull;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public BankFullException() : base("Bank full")
    {
    }

    public BankFullException(string message) : base(message)
    {
    }

    public BankFullException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static BankFullException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
