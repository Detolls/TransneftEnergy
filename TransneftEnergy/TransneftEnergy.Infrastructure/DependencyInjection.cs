using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransneftEnergy.Infrastructure.Data;

namespace TransneftEnergy.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TransneftEnergyDatabase");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            });

            services.AddScoped<ApplicationDbContextInitialiser>();

            return services;
        }
    }
}
