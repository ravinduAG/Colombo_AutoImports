using ColomboAutoImports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColomboAutoImports.Infrastructure.EntityConfigurations
{
    public class FuelTypeEntityConfiguration : IEntityTypeConfiguration<FuelTypeEntity>
    {
        public void Configure(EntityTypeBuilder<FuelTypeEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(150);

            builder.HasMany(m => m.Vehicles)
                .WithOne(s => s.FuelType)
                .HasForeignKey(s => s.FuelTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
