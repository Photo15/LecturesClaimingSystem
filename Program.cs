using LecturesClaimingSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace LecturesClaimingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add the DbContext service and configure SQL Server connection for EmployeeContext, LecturesContext, and ClaimContext.
            builder.Services.AddDbContext<EmployeeContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<LecturesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

            // Register ClaimContext service
            builder.Services.AddDbContext<ClaimContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionString")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable routing
            app.UseRouting();

            // Enable authorization
            app.UseAuthorization();

            // Set up default routing to HomeController with Index as the default action.
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Default action set to Index

            app.Run();
        }
    }
}
