using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smakownia.Basket.Domain.Repositories;
using Smakownia.Basket.Infrastructure.Repositories;
using Smakownia.Events;
using StackExchange.Redis;

namespace Smakownia.Products.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<ProductDeletedEventConsumer>();

            busConfigurator.UsingRabbitMq((ctx, configurator) =>
            {
                configurator.Host(new Uri(configuration.GetConnectionString("RabbitMQ")!));

                configurator.ConfigureEndpoints(ctx);
            });
        });

        services.AddSingleton<IConnectionMultiplexer>(
            sp => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));

        services.AddTransient<IBasketsRepository, BasketsRepository>();

        return services;
    }
}
