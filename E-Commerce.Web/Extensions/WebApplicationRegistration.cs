using DomainLayer.Contracts;
using E_Commerce.Web.Controllers;

namespace E_Commerce.Web;

public static class WebApplicationRegistration
{
    public static async Task SeedDataBaseAsync(this WebApplication app)
    {
        using var Scope = app.Services.CreateScope();
        var ObjectOfDataSeeding = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
        await ObjectOfDataSeeding.DataSeedAsync();
        await ObjectOfDataSeeding.IdentityDataSeedAsync();
    }

    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionMiddleWare>();

        return app;
    }

    public static IApplicationBuilder UseSwaggerMiddleWares(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
