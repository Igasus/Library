namespace Library.Application.Exceptions;

public abstract class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
}