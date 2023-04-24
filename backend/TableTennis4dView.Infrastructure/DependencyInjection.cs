using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TableTennis4dView.Application.Common.Interfaces;
using TableTennis4dView.Core.Entities.Identity;
using TableTennis4dView.Core.Repositories.Command;
using TableTennis4dView.Core.Repositories.Command.Base;
using TableTennis4dView.Core.Repositories.Query;
using TableTennis4dView.Core.Repositories.Query.Base;
using TableTennis4dView.Infrastructure.Data;
using TableTennis4dView.Infrastructure.Repository.Command;
using TableTennis4dView.Infrastructure.Repository.Command.Base;
using TableTennis4dView.Infrastructure.Repository.Query;
using TableTennis4dView.Infrastructure.Repository.Query.Base;
using TableTennis4dView.Infrastructure.Services;

namespace TableTennis4dView.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TableTennis4dViewAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(TableTennis4dViewAppContext).Assembly.FullName)
                ));

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<TableTennis4dViewAppContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false; // For special character
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            });


            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddTransient<ITechniqueQueryRepository, TechniqueQueryRepository>();
            services.AddTransient<ICameraViewQueryRepository, CameraViewQueryRepository>();
            services.AddTransient<IPlayerQueryRepository, PlayerQueryRepository>();
            
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddTransient<ITechniqueCommandRepository, TechniqueCommandRepository>();
            services.AddTransient<ICameraViewCommandRepository, CameraViewCommandRepository>();
            services.AddTransient<IPlayerCommandRepository, PlayerCommandRepository>();

            return services;
        }
    }
}
