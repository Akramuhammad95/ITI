using AutoMapper;
using Core.Interfaces;
using Core.Mapping;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<CourseService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<StudentService>(); 

            services.AddMemoryCache();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}