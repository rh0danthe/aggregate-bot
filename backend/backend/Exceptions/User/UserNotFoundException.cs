using backend.Exceptions.Shared;

namespace backend.Exceptions.User;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string message) : base(message)
    {
    }
}