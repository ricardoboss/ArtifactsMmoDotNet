namespace ArtifactsMmoDotNet.Sdk.Interfaces;

public interface IInputRequester
{
    Task<string> AskAsync(string message, bool concealed = false);
}
