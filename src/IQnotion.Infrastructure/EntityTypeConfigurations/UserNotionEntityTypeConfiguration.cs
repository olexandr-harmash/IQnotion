using IQnotion.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserNotionEntityTypeConfiguration  : IEntityTypeConfiguration<UserNotion>
{
    public void Configure(EntityTypeBuilder<UserNotion> builder)
    {
        builder.HasKey(un => new { un.Id, un.UserId, un.FileId });

        // Настройка полей
        builder.Property(un => un.Action)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(un => un.ViewedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Настройка внешнего ключа к Notion (FileId)
        builder.HasOne<Notion>()
            .WithMany()
            .HasForeignKey(un => un.FileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}