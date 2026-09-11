using Dplomty.BL.Interface;
using Dplomty.BL.Service;
using Dplomty.DAL;
using Dplomty.DAL.Entities;
using Dplomty.DAL.Interface;
using Dplomty.DAL.Reposatories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dplomty.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DI Container
            builder.Services.AddScoped<IStudentService,StudentService>();
            builder.Services.AddScoped<IStudentRepo,StudentRepo>();
            // builder.Services.AddKeyedScoped<>

            #region Connection string Configration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(connectionString)
            );
            #endregion

            #region Identity Configration 
            
            builder.Services.AddIdentityCore<ApplicationUser>(Option =>
            {
                Option.Password.RequiredLength = 8;
                Option.Password.RequireNonAlphanumeric = true;
                Option.Password.RequireUppercase = true;
                Option.Password.RequireLowercase = true;
                Option.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
