using Domain.Entities.Membership;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public static class DataContextInjections
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null, ServiceLifetime contextLifetime = ServiceLifetime.Scoped, ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        {
            services.AddDbContext<DataContext>(optionsAction, contextLifetime, optionsLifetime);

            services.AddIdentityCore<ResumeUser>()
                .AddRoles<ResumeRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<ResumeIdentityErrorDescriber>()
                .AddUserManager<UserManager<ResumeUser>>()
                .AddSignInManager<SignInManager<ResumeUser>>()
                .AddRoleManager<RoleManager<ResumeRole>>();

           
            return services;
        }
    }


}
