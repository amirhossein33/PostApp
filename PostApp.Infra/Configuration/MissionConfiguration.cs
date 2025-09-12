using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostApp.Domain.Entities;

namespace PostApp.Infra.Configuration
{
    public class MissionConfiguration : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(m => m.Origin)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.Destination)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.CreatedDatetime)
                .IsRequired();

            builder.Property(m => m.ManagerId)
                .IsRequired();

            builder.Property(m => m.DriverId)
                .IsRequired();

            builder.HasOne(m => m.Manager)
                .WithMany(mg => mg.Missions)
                .HasForeignKey(m => m.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Driver)
                .WithMany(d => d.Missions)
                .HasForeignKey(m => m.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(m => m.CreatedDatetime);
            builder.HasIndex(m => new { m.ManagerId, m.CreatedDatetime });
            builder.HasIndex(m => new { m.DriverId, m.CreatedDatetime });
        }
    }

}
