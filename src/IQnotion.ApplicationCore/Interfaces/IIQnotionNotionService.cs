using IQnotion.ApplicationCore.Models;

namespace IQnotion.ApplicationCore.Interfaces;

public interface IIQnotionNotionService
{
    public Task<Notion> RetrieveNotionNotViewedByUser(int userId, string type);
}