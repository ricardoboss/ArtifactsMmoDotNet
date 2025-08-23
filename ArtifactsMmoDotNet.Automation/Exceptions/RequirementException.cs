using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Exceptions;

public class RequirementException : Exception
{
    public required IRequirement Requirement { get; init; }

    public RequirementException()
    {
    }

    public RequirementException(string message) : base(message)
    {
    }

    public RequirementException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
