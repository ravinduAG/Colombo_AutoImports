using ColomboAutoImports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColomboAutoImports.Infrastructure.EntityConfigurations
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<VehicleEntity>
    {
        public void Configure(EntityTypeBuilder<VehicleEntity> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(v => v.Year)
                .IsRequired();

            builder.Property(v => v.Color)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(v => v.SubModel)
                .WithMany(s => s.Vehicles)
                .HasForeignKey(v => v.SubModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.FuelType)
                .WithMany(s => s.Vehicles)
                .HasForeignKey(v => v.FuelTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
