namespace IQnotion.ApplicationCore.Models;

public class Notion
{
    public int Id { get; set; }
    public string FileName { get; set; } = null!;
    public string RelativePath { get; set; } = null!;
    public string Area { get; set; } = null!;
    public string Field { get; set; } = null!;
    public List<string> SupportLanguages { get; set; } = null!;
}