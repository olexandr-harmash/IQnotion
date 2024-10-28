using IQnotion.ApplicationCore.Models;

namespace IQnotion.ApplicationCore.Interfaces;

public interface IIQnotionNotionRepository
{
    public Task<Notion?> RetrieveNotionNotViewedByUser(int userId, string type);
}