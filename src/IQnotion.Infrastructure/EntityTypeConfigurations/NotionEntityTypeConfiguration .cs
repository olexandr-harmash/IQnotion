using IQnotion.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IQnotion.Infrastructure.EntityTypeConfigurations;

public class NotionEntityTypeConfiguration  : IEntityTypeConfiguration<Notion>
{
    public void Configure(EntityTypeBuilder<Notion> builder) 
    {
        builder.HasKey(n => n.Id);

        // Настройка полей
        builder.Property(n => n.FileName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(n => n.RelativePath)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(n => n.Area)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(n => n.Field)
            .IsRequired()
            .HasMaxLength(255);
    }
}