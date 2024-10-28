using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Models;
using IQnotion.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class EFIQnotionRepository : IIQnotionNotionRepository
{
    readonly IQnotionDbContext _context = null!;

    public EFIQnotionRepository(IQnotionDbContext context)
    {
        _context = context;
    }

    public Task<Notion?> RetrieveNotionNotViewedByUser(int userId, string type)
    {
        return (
            _context.Notions
                .Where(n => n.Type == type)
                .GroupJoin(
                    _context.UserNotions.Where(u => u.UserId == userId),
                    notion => notion.Id,
                    history => history.FileId,
                    (notion, histories) => new { Notion = notion, UserHistories = histories }
                )
                .Where(joined => !joined.UserHistories.Any())
                .Select(joined => joined.Notion)
                .FirstOrDefaultAsync()
        );
    }

}