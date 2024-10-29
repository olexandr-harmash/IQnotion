namespace IQnotion.ApplicationCore.Exceptions;

public class UserRegistrationException : Exception
{
    public UserRegistrationException(string username, IEnumerable<string> details) : base($"Can't register user '{username}' due to: {string.Join(", ", details)}") {}
}