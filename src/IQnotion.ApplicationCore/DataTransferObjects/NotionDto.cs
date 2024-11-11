namespace IQnotion.ApplicationCore.DataTransferObjects;

public record NotionDetailedDto
{
    public int Id { get; init; }
    public string FileName { get; init; } = null!;
    public string RelativePath { get; init; } = null!;
    public string Field { get; init; } = null!;
    public string Area { get; init; } = null!;
    public List<string> SupportLanguages { get; init; } = null!;
}