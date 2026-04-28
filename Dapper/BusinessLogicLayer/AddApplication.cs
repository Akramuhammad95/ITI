using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;

namespace BusinessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // 🔹 Services
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService, DepartmentService>();

        return services;
    }
}