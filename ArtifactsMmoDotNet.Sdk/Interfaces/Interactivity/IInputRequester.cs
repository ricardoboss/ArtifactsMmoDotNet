namespace ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;

public interface IInputRequester
{
    Task<string> PromptAsync(string text, bool concealed = false, CancellationToken cancellationToken = default);
}
