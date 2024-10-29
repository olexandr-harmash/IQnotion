namespace IQnotion.ApplicationCore.Interfaces;

public interface IIQnotionUnitOfWork
{
    public Task SaveChangesAsync();
    public IIQnotionNotionRepository Notion { get; }
    public IIQnotionUserNotionRepository UserNotion { get; }
}