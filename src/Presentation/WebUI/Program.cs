using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Services;
using Services.Implementation;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);
            builder.Services.AddDbContext<DbContext,DataContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"));
            });

            builder.Services.AddScoped<IContactPostService, ContactPostService>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}");
            app.MapControllerRoute(name:"default",pattern:"{controller=home}/{action=index}/{id?}");
         

            app.Run();
        }
    }
}