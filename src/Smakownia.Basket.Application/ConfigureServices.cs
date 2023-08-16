using Microsoft.Extensions.DependencyInjection;
using Smakownia.Basket.Application;

namespace Smakownia.Products.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ApplicationAssemblyReference.Assembly));
        services.AddAutoMapper(typeof(BasketMapperProfile));

        return services;
    }
}
