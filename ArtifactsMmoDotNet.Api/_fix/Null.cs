using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;

// ReSharper disable once CheckNamespace
namespace ArtifactsMmoDotNet.Api.Generated.Models;

public class Null : IBackedModel, IParsable
{
    private Null()
    {
        BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
    }

    public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() => new Dictionary<string, Action<IParseNode>>();

    public void Serialize(ISerializationWriter writer) => writer.WriteNullValue(null);

    public static Null CreateFromDiscriminatorValue(IParseNode parseNode)
    {
        _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));

        return new Null();
    }

    public IBackingStore BackingStore { get; private set; }
}
