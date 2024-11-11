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

    public async Task<NotionDetailedDto> RetrieveNotionNotViewedByUserAsync(int userId, string area, string field)
    {
        var notion = await _unitOfWork.Notion.RetrieveNotionNotViewedByUserAsync(userId, area, field);

        if (notion == null)
        {
            throw new NotionNotFoundException(userId, field);
        }

        var userNotion = new UserNotion
        {
            FileId = notion.Id,
            UserId = userId
        };

        _unitOfWork.UserNotion.AddUserNotion(userNotion);

        await _unitOfWork.SaveChangesAsync();

        return new NotionDetailedDto
        {
            Id = notion.Id,
            FileName = notion.FileName,
            RelativePath = notion.RelativePath,
            Area = notion.Area,
            Field = notion.Field,
            SupportLanguages = notion.SupportLanguages
        };
    }
}