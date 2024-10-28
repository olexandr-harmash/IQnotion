using IQnotion.ApplicationCore.Models;
using IQnotion.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace IQnotion.Infrastructure;

public class IQnotionDbContext : DbContext
{
    public DbSet<Notion> Notions = null!;
    public DbSet<UserNotion> UserNotions = null!;

    public IQnotionDbContext(DbContextOptions<IQnotionDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NotionEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserNotionEntityTypeConfiguration());
    }
}