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

            builder.Property(d => d.IsRunning)
                .IsRequired();

            builder.Property(d => d.Active)
                .IsRequired();


            builder.HasIndex(d => d.DriverNumber)
                .IsUnique();
        }
    }

}
