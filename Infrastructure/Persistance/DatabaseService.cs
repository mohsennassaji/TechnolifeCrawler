using Application.Services;
using Domain.SystemEntities;
using Domain.TechnoLifeProducts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistance
{
    internal class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions<DatabaseService> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<GeneralSetting> GeneralSettings => Set<GeneralSetting>();

        public DbSet<LogManagment> LogManagments => Set<LogManagment>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<ProductSpecification> ProductSpecifications => Set<ProductSpecification>();

        public DbSet<ProductImage> ProductImages => Set<ProductImage>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
