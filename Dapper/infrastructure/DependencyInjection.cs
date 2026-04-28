using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Data;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // 🔹 DB Context
        services.AddSingleton<DapperContext>();

        // 🔹 Repositories
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;
    }
}