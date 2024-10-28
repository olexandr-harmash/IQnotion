namespace IQnotion.ApplicationCore.DataTransferObjects;

public class NotionDetailedDto
{
    public int Id;
    public int FileName;
    public int RelativePath;
    public string Type = null!;
    public List<string> SupportLanguages = null!;
}