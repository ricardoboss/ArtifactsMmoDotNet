namespace ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;

public interface IInputRequester
{
    Task<string> AskAsync(string message, bool concealed = false);
}
