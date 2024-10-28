using IQnotion.ApplicationCore.Exceptions;
using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Models;

namespace IQnotion.ApplicationCore.Services;

public class IQnotionNotionService : IIQnotionNotionService
{
    readonly IIQnotionNotionRepository _repository = null!;

    public IQnotionNotionService(IIQnotionNotionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Notion> RetrieveNotionNotViewedByUser(int userId, string type)
    {
        var notion = await _repository.RetrieveNotionNotViewedByUser(userId, type);

        if (notion == null)
        {
            throw new NotionNotFoundException(userId, type);
        }

        return notion;
    }
}