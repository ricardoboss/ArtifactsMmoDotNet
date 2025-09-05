namespace ArtifactsMmoDotNet.Automation.Models;

public class ActionExecutionResult
{
    public static ActionExecutionResult Successful() => new() { Success = true, Retryable = false };

    public static ActionExecutionResult Failed(string message, bool attemptRetry) =>
        new() { Success = false, Retryable = attemptRetry, Message = message };

    public required bool Success { get; init; }

    public required bool Retryable { get; init; }

    public string? Message { get; init; }
}
