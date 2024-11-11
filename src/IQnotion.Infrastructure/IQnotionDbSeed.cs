using IQnotion.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IQnotion.Infrastructure;

public class IQnotionDbSeed
{
    private readonly IQnotionDbContext _context;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public IQnotionDbSeed(IQnotionDbContext context, RoleManager<IdentityRole<int>> roleManager)
    {
        _context = context;
        _roleManager = roleManager;
    }

    public async Task SeedAsync()
    {
        _context.Database.Migrate();
        
        // Проверьте, существуют ли уже данные
        if (_context.Notions.Any() || _context.UserNotions.Any())
        {
            return;
        }

        // Создание начальных данных для таблицы Notion
        var notions = new List<Notion>
        {
            new Notion { FileName = "id123456789-overview", RelativePath = "programming/asp-dot-net-core/id123456789-overview/id123456789-overview.md", Area = "programming", Field = "asp-dot-net-core", SupportLanguages = new List<string> { "en", "ru" } },
            new Notion { FileName = "id123456780-overview", RelativePath = "programming/c-sharp/id123456780-overview/id123456780-overview.md", Area = "programming", Field = "c-sharp", SupportLanguages = new List<string> { "en", "ru" } },
            // Добавьте другие данные по необходимости
        };

        await _context.Notions.AddRangeAsync(notions);
        await _context.SaveChangesAsync();

        // Создание начальных данных для таблицы UserNotion
        var userNotions = new List<UserNotion>
        {
            new UserNotion { UserId = 1, FileId = notions[0].Id},
            // Добавьте другие данные по необходимости
        };

        await _context.UserNotions.AddRangeAsync(userNotions);
        await _context.SaveChangesAsync();
    }
}