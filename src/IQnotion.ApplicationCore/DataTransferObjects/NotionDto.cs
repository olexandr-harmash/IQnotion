namespace IQnotion.ApplicationCore.DataTransferObjects;

public record NotionDetailedDto
{
    public int Id { get; init; }
    public int FileName { get; init; }
    public int RelativePath { get; init; }
    public string Type { get; init; } = null!;
    public List<string> SupportLanguages { get; init; } = null!;
}