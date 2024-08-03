namespace ArtifactsMmoDotNet.Sdk.Interfaces;

public interface IKnownLocation
{
    string Name { get; }

    (int x, int y) Position { get; }
}
