namespace backend.Exceptions.Shared;

public class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message)
    {
    }
}