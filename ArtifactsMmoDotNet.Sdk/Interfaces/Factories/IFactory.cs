namespace ArtifactsMmoDotNet.Sdk.Interfaces.Factories;

public interface IFactory<out T> where T : class
{
    T Create();
}
