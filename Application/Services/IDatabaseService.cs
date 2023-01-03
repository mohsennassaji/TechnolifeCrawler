using Domain.SystemEntities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public interface IDatabaseService
    {
        //General
        DbSet<GeneralSetting> GeneralSettings { get; }
        DbSet<LogManagment> LogManagments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
