using Domain.SystemEntities;
using Domain.TechnoLifeProducts;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public interface IDatabaseService
    {
        //Technolife product
        DbSet<TechnoLifeProduct> TechnoLifeProducts { get; }
        DbSet<TechnoLifeProductDetail> TechnoLifeProductDetails { get; }

        //General
        DbSet<GeneralSetting> GeneralSettings { get; }
        DbSet<LogManagment> LogManagments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
