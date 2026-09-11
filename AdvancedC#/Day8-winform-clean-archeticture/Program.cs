using System;

using Microsoft.Extensions.DependencyInjection;

using ApplicationLayer.Interfaces;
using ApplicationLayer.Services;
using ApplicationLayer.Validation;
namespace Day8_winform_clean_archeticture
{

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static ServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<IUserService, UserService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<UserValidator>();

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }
    }
}