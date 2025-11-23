using ColomboAutoImports.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColomboAutoImports.Infrastructure.EntityConfigurations
{
    public class SubModelEntityConfiguration : IEntityTypeConfiguration<SubModelEntity>
    {
        public void Configure(EntityTypeBuilder<SubModelEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(s => s.Model)
                .WithMany(m => m.SubModels)
                .HasForeignKey(s => s.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Vehicles)
                .WithOne(v => v.SubModel)
                .HasForeignKey(v => v.SubModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
