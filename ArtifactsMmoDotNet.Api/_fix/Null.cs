using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;

// ReSharper disable once CheckNamespace
namespace ArtifactsMmoDotNet.Api.Generated.Models;

public class Null : IParsable
{
    private Null()
    {
    }

    public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() => new Dictionary<string, Action<IParseNode>>();

    public void Serialize(ISerializationWriter writer) => writer.WriteNullValue(null);

    public static Null CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));

        return new Null();
    }
}
