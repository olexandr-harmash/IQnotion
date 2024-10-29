using IQnotion.ApplicationCore.Interfaces;

namespace IQnotion.Infrastructure.Repositories;

public class EFIQnotionUnitOfWork : IIQnotionUnitOfWork
{
    readonly IQnotionDbContext _context = null!;
    readonly IIQnotionNotionRepository _notion = null!;
    readonly IIQnotionUserNotionRepository _userNotion = null!;

    public EFIQnotionUnitOfWork(IQnotionDbContext context, IIQnotionNotionRepository notion, IIQnotionUserNotionRepository userNotion)
    {
        _notion = notion;
        _context = context;
        _userNotion = userNotion;
    }

    public IIQnotionNotionRepository Notion => _notion;

    public IIQnotionUserNotionRepository UserNotion => _userNotion;

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}