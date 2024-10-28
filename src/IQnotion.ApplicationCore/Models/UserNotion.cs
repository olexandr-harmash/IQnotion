namespace IQnotion.ApplicationCore.Models;

public class UserNotion
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FileId { get; set; }
    public DateTime ViewedAt { get; set; }
    public string Action { get; set; } = null!;
}