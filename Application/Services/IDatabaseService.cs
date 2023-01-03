using Domain.SystemEntities;
using Domain.TechnoLifeProducts;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public interface IDatabaseService
    {
        //Technolife product
        DbSet<Product> TechnoLifeProducts { get; }
        DbSet<ProductSpecification> TechnoLifeProductDetails { get; }

        //General
        DbSet<GeneralSetting> GeneralSettings { get; }
        DbSet<LogManagment> LogManagments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
