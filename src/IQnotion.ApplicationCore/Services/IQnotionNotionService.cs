using IQnotion.ApplicationCore.DataTransferObjects;
using IQnotion.ApplicationCore.Exceptions;
using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Models;

namespace IQnotion.ApplicationCore.Services;

public class IQnotionNotionService : IIQnotionNotionService
{
    readonly IIQnotionUnitOfWork _unitOfWork = null!;

    public IQnotionNotionService(IIQnotionUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Notion>> RetrieveNotionViewedByUserAsync(int userId)
    {
        return await _unitOfWork.Notion.RetrieveNotionViewedByUserAsync(userId);
    }

    public async Task<Notion> RetrieveNotionNotViewedByUserAsync(int userId, string type)
    {
        var notion = await _unitOfWork.Notion.RetrieveNotionNotViewedByUserAsync(userId, type);

        if (notion == null)
        {
            throw new NotionNotFoundException(userId, type);
        }

        var userNotion = new UserNotion
        {
            FileId = notion.Id,
            UserId = userId,
            Action = "Viewed"
        };

        _unitOfWork.UserNotion.AddUserNotion(userNotion);

        await _unitOfWork.SaveChangesAsync();

        return notion;
    }
}