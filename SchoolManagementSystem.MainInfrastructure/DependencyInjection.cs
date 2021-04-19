using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.MainInfrastructure.Data;

namespace SchoolManagementSystem.MainInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder
                        .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddIdentity<ApplicationUser, AppUserRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}