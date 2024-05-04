using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OGANI.UserService.Domain.Interfaces;
using OGANI.UserService.Infrastructure.Persistance;
using OGANI.UserService.Infrastructure.Repositories;

namespace OGANI.UserService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OganiDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbContext") ?? "")
                    .EnableSensitiveDataLogging());
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
          
       
        }
    }
}

