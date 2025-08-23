using ArtifactsMmoDotNet.Api.Generated.Models;

namespace ArtifactsMmoDotNet.Automation.Exceptions;

public class UnknownGatherLocationException : Exception
{
    public GatheringSkill? Skill { get; init; }

    public string? ItemCode { get; init; }

    public UnknownGatherLocationException()
    {
    }

    public UnknownGatherLocationException(string message) : base(message)
    {
    }

    public UnknownGatherLocationException(string message, Exception inner) : base(message, inner)
    {
    }
}
