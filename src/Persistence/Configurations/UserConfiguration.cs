using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(u => u.Id);
        builder.Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();
        builder.Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();
        builder.Property(u => u.HashedPassword)
            .IsRequired();
        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");
        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("Email")
                .HasMaxLength(200)
                .IsRequired();
        });

        builder.HasIndex("Email").IsUnique();
    }
}
