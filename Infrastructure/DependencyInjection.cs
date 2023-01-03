using Application.Services;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseService>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(DatabaseService).Assembly.FullName)));

            services.AddTransient<IDatabaseService>(provider => provider.GetRequiredService<DatabaseService>());

            services.AddTransient<ILogManagmentService, LogManagmentService>();
            services.AddTransient<IGeneralSettingService, GeneralSettingService>();

            return services;
        }
    }
}
