using IQnotion.ApplicationCore.DataTransferObjects;
using IQnotion.ApplicationCore.Models;

namespace IQnotion.ApplicationCore.Interfaces;

public interface IIQnotionNotionService
{
    public Task<Notion> RetrieveNotionNotViewedByUserAsync(int userId, string type);
    public Task<List<Notion>> RetrieveNotionViewedByUserAsync(int userId);
}