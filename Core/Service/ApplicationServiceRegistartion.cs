using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;

namespace Service
{
    public static class ApplicationServiceRegistartion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            
            return services;
        }
    }
}
