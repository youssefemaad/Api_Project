using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistence.Data;
using Presistence.Repository;

namespace Presistence;

public static class InfraStractureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDataSeeding, DataSeeding>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<StoreDbContext>(Opt =>
        {
            Opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}
