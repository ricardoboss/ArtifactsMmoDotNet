using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Bank;

public class BankTransactionInProgressException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.BankTransactionInProgress;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public BankTransactionInProgressException() : base("Bank transaction in progress")
    {
    }

    public BankTransactionInProgressException(string message) : base(message)
    {
    }

    public BankTransactionInProgressException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static BankTransactionInProgressException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new();
    }
}
