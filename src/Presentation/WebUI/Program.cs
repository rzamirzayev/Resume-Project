using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using Repositories;
using Services;
using Services.Implementation;
using Services.SkillPosts;
using FluentValidation;
using FluentValidation.AspNetCore;
using WebUI.Filters;
using Domain.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new IoCFactory());

            builder.Services.AddControllersWithViews(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                   .Build();
                cfg.Filters.Add(new AuthorizeFilter(policy));


                cfg.Filters.Add(new ValidationActionFilter());
                cfg.Filters.Add(new GlobalExceptionFilter());


            });

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            builder.Services.AddDataContext(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"));
            });

            builder.Services.AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = true;
            });
            builder.Services.AddValidatorsFromAssemblyContaining<IServiceInterface>(includeInternalTypes: true);



            builder.Services.Configure<IdentityOptions>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;

                //cfg.Lockout.AllowedForNewUsers = true;
                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

                if (builder.Environment.IsDevelopment())
                {
                    cfg.Password.RequiredUniqueChars = 1;
                    cfg.Password.RequiredLength = 5;
                    cfg.Password.RequireNonAlphanumeric = false;
                    cfg.Password.RequireUppercase = false;
                    cfg.Password.RequireLowercase = false;
                    cfg.Password.RequireDigit = false;
                }



            });

            //builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddCookie(IdentityConstants.ApplicationScheme, cfg =>
            //{
            //    cfg.LoginPath = "/signin.html";
            //    cfg.AccessDeniedPath= "/accessdenied.html"; 
            //    cfg.Cookie.Name = "resume";
            //    cfg.Cookie.HttpOnly = true;
            //});
            builder.Services.AddAuthentication(cfg =>
            {
                cfg.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";
                cfg.Cookie.Name = "ogani";
                cfg.Cookie.HttpOnly = true;
            });



            builder.Services.AddAuthorization(cfg =>
            {
                    cfg.AddPolicy("admin.blog.get", opt =>
                    {
                        opt.RequireAssertion(hendler =>
                        {

                            return hendler.User.IsInRole("SuperAdmin") || hendler.User.HasClaim("admin.blog.get", "1");
                        });
                    });
            });

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapGet("/accessdenied.html", async (context) =>
            {
                context.Response.Clear();
                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(File.ReadAllText("wwwroot/error-pages/404.html"));
            });
            app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}");
            app.MapControllerRoute(name:"default",pattern:"{controller=home}/{action=index}/{id?}");
         

            app.Run();
        }
    }
}