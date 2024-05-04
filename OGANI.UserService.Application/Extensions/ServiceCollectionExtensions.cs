using Microsoft.Extensions.DependencyInjection;
using OGANI.UserService.Domain.Interfaces;

namespace OGANI.UserService.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IAddressService, AddressService>();
            return services; 
        }
    }
}

