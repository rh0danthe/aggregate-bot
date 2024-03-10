using backend.Exceptions.Shared;

namespace backend.Exceptions.Message;

public class MessageBadRequestException : BadRequestException
{
    public MessageBadRequestException(string message) : base(message)
    {
    }
}