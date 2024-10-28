namespace IQnotion.ApplicationCore.Models;

public class UserNotion
{
    public int Id;
    public int UserId;
    public int FileId;
    public DateTime ViewedAt;
    public string Action = null!;
}