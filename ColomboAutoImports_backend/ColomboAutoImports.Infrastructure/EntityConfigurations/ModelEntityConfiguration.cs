using ColomboAutoImports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColomboAutoImports.Infrastructure.EntityConfigurations
{
    public class ModelEntityConfiguration : IEntityTypeConfiguration<ModelEntity>
    {
        public void Configure(EntityTypeBuilder<ModelEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(150);

            builder.HasOne(m => m.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.SubModels)
                .WithOne(s => s.Model)
                .HasForeignKey(s => s.ModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
