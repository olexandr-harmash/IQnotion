using IQnotion.ApplicationCore.Models;

namespace IQnotion.ApplicationCore.Interfaces;

public interface IIQnotionNotionRepository
{
    public Task<Notion?> RetrieveNotionNotViewedByUserAsync(int userId, string area, string type);
}