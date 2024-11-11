using IQnotion.ApplicationCore.DataTransferObjects;

namespace IQnotion.ApplicationCore.Interfaces;

public interface IIQnotionNotionService
{
    public Task<NotionDetailedDto> RetrieveNotionNotViewedByUserAsync(int userId, string area, string field);
}