using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostApp.Domain.Entities;

namespace PostApp.Infra.Configuration
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.ManagerNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(m => m.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(m => m.CreatedAt)
                .IsRequired();

            builder.Property(m => m.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            // Unique constraints
            builder.HasIndex(m => m.Username)
                .IsUnique();

            builder.HasIndex(m => m.Email)
                .IsUnique();

            builder.HasIndex(m => m.ManagerNumber)
                .IsUnique();
        }
    }
}
