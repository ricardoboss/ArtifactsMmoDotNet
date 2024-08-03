namespace ArtifactsMmoDotNet.Sdk.Interfaces.Game;

public interface IKnownLocation
{
    string Name { get; }

    (int x, int y) Position { get; }
}
