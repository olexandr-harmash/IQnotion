using IQnotion.ApplicationCore.DataTransferObjects;
using IQnotion.ApplicationCore.Interfaces;
using IQnotion.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace IQnotion.Infrastructure.Repositories;

public class EFIQnotionUserNotionRepository : IIQnotionUserNotionRepository
{
    readonly IQnotionDbContext _context = null!;

    public EFIQnotionUserNotionRepository(IQnotionDbContext context)
    {
        _context = context;
    }

    public UserNotion AddUserNotion(UserNotion userNotion)
    {
        return (  
            _context.UserNotions.Add(userNotion)
                .Entity
        );
    }
}