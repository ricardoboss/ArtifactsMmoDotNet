namespace ArtifactsMmoDotNet.Automation.Exceptions;

public class UnobtainableItemException : RequirementException
{
    public UnobtainableItemException()
    {
    }

    public UnobtainableItemException(string message) : base(message)
    {
    }

    public UnobtainableItemException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
