using IQnotion.ApplicationCore.DataTransferObjects;
using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace IQnotion.Infrastructure.Repositories;

public class EFIQnotionRepository : IIQnotionNotionRepository
{
    readonly IQnotionDbContext _context = null!;

    public EFIQnotionRepository(IQnotionDbContext context)
    {
        _context = context;
    }

    public Task<Notion?> RetrieveNotionNotViewedByUserAsync(int userId, string type)
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
                .AsNoTracking()
                .FirstOrDefaultAsync()
        );
    }

    public Task<List<Notion>> RetrieveNotionViewedByUserAsync(int userId)
    {
        return (  
            _context.UserNotions
                .Where(un => un.UserId == userId)
                .GroupJoin(
                    _context.Notions,
                    history => history.FileId,
                    notion => notion.Id,
                    (history, notions) => notions.First()
                )     
                .AsNoTracking()
                .ToListAsync()
        );
    }
}