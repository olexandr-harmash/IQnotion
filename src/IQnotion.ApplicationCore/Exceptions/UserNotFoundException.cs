namespace IQnotion.ApplicationCore.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(int userId) : base($"Can't find user with id: '{userId}'") {}
}