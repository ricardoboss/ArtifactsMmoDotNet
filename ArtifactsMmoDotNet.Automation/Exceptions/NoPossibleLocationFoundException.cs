namespace ArtifactsMmoDotNet.Automation.Exceptions;

public class NoPossibleLocationFoundException : RequirementException
{
    public NoPossibleLocationFoundException()
    {
    }

    public NoPossibleLocationFoundException(string message) : base(message)
    {
    }

    public NoPossibleLocationFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}
