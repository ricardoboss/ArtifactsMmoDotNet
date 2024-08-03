namespace ArtifactsMmoDotNet.Sdk.Interfaces;

public interface IFactory<out T> where T : class
{
    T Create();
}
