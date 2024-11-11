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

    public Task<Notion?> RetrieveNotionNotViewedByUserAsync(int userId, string area, string field)
    {
        return (
            _context.Notions
                .Where(n => n.Area == area && n.Field == field && !_context.UserNotions
                    .Any(un => un.UserId == userId && un.FileId == n.Id))
                .AsNoTracking()
                .FirstOrDefaultAsync()
        );
    }
}