using Microsoft.EntityFrameworkCore;
using ColomboAutoImports.Core.Entities;
using ColomboAutoImports.Infrastructure.EntityConfigurations;

namespace ColomboAutoImports.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ModelEntity> Models => Set<ModelEntity>();
        public DbSet<BrandEntity> Brands => Set<BrandEntity>();
        public DbSet<SubModelEntity> SubModels => Set<SubModelEntity>();
        public DbSet<VehicleEntity> Vehicles => Set<VehicleEntity>();
        public DbSet<FuelTypeEntity> FuelTypes => Set<FuelTypeEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubModelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FuelTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
