namespace IQnotion.ApplicationCore.Exceptions;

public class NotionNotFoundException : Exception
{
    public NotionNotFoundException(int id) : base($"Notion with id: {id} not found.") {}
    public NotionNotFoundException(int userId, string type) : base($"Notion with user id: {userId} and type: {type} not found.") {}
}