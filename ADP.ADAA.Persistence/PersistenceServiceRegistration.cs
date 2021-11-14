using ADAA.ADP.Application.Contracts.Persistence;
using ADP.ADAA.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ADP.ADAA.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ADAADbContext>(options =>
                options.UseOracle(configuration.GetConnectionString("ADAAConnectionString"), b=> b.MigrationsAssembly(typeof(ADAADbContext).Assembly.FullName).UseOracleSQLCompatibility("12")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
