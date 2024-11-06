using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;

namespace ArtifactsMmoDotNet.Api.Exceptions;

public abstract class CustomApiException : ApiException, IParsable
{
    /// <inheritdoc/>
    protected CustomApiException(string message) : base(message)
    {
    }

    /// <inheritdoc/>
    protected CustomApiException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
    {
        return new Dictionary<string, Action<IParseNode>>
        {
            { "error", n => Error = n.GetObjectValue(ErrorContent.CreateFromDiscriminatorValue) },
        };
    }

    public ErrorContent? Error { get; set; }

    public void Serialize(ISerializationWriter writer)
    {
        throw new NotSupportedException($"Serialization is not supported for {typeof(CustomApiException)}.");
    }
}

public class ErrorContent : IParsable
{
    public int? Code { get; set; }

    public string? Message { get; set; }

    public IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
    {
        return new Dictionary<string, Action<IParseNode>>
        {
            { "code", n => Code = n.GetIntValue() },
            { "message", n => Message = n.GetStringValue() },
        };
    }

    public void Serialize(ISerializationWriter writer)
    {
        throw new NotSupportedException("Serialization is not supported for ErrorContent.");
    }

    public static ErrorContent CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        ArgumentNullException.ThrowIfNull(parseNode);

        return new ErrorContent();
    }
}
