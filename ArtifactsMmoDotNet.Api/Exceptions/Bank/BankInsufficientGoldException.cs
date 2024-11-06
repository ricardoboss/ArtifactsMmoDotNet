using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions.Bank;

public class BankInsufficientGoldException : CustomApiException
{
    public static CustomApiStatusCode CustomCode => CustomApiStatusCode.BankInsufficientGold;

    public static string CustomCodeIntStr => ((int)CustomCode).ToString();

    public BankInsufficientGoldException() : base("Bank insufficient gold")
    {
    }

    public BankInsufficientGoldException(string message) : base(message)
    {
    }

    public BankInsufficientGoldException(string message, Exception innerException) : base(message,
        innerException)
    {
    }

    public static BankInsufficientGoldException CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new BankInsufficientGoldException();
    }
}
