using IQnotion.ApplicationCore.Models;
using IQnotion.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace IQnotion.Infrastructure;

public class IQnotionDbContext : DbContext
{
    public DbSet<Notion> Notions { get; set; } = null!;
    public DbSet<UserNotion> UserNotions { get; set; } = null!;

    public IQnotionDbContext(DbContextOptions<IQnotionDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NotionEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserNotionEntityTypeConfiguration());
    }
}