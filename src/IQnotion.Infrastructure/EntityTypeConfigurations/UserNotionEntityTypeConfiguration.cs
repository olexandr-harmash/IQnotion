using IQnotion.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserNotionEntityTypeConfiguration  : IEntityTypeConfiguration<UserNotion>
{
    public void Configure(EntityTypeBuilder<UserNotion> builder)
    {
        builder.HasKey(un => new { un.UserId, un.FileId });
    }
}