namespace ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;

public interface IOutput
{
    Task ShowConfirmationAsync(string message, CancellationToken cancellationToken = default);

    Task LogInfoAsync(string message, CancellationToken cancellationToken = default);
}
