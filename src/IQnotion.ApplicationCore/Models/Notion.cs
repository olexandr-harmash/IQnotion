namespace IQnotion.ApplicationCore.Models;

public class Notion
{
    public int Id;
    public string FileName = null!;
    public string RelativePath = null!;
    public string Type = null!;
    public List<string> SupportLanguages = null!;
}