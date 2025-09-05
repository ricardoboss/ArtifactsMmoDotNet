namespace ArtifactsMmoDotNet.Automation.Exceptions;

public class ActionException : Exception
{
    public ActionException()
    {
    }

    public ActionException(string message) : base(message)
    {
    }

    public ActionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
