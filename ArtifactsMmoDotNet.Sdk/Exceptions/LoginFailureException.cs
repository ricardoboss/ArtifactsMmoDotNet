namespace ArtifactsMmoDotNet.Sdk.Exceptions;

public class LoginFailureException : Exception
{
    public LoginFailureException(string message) : base(message)
    {
    }

    public LoginFailureException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
