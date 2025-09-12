using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostApp.Domain.Entities;

namespace PostApp.Infra.Configuration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.DriverNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(d => d.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(d => d.CreatedAt)
                .IsRequired();

            builder.Property(d => d.IsRunning)
                .IsRequired();

            builder.Property(d => d.Active)
                .IsRequired();

            // Unique constraints
            builder.HasIndex(d => d.Username)
                .IsUnique();

            builder.HasIndex(d => d.Email)
                .IsUnique();

            builder.HasIndex(d => d.DriverNumber)
                .IsUnique();
        }
    }
}