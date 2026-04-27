using Domain.Interfacese;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DbDi
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // =========================
            // DbContext + Eager Loading support
            // =========================
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                )
            );

            // =========================
            // Lazy Loading (PROXIES)
            // =========================
            services.AddDbContext<AppDbContext>(options =>
                options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .UseLazyLoadingProxies()
            );

            // Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}