using Microsoft.Extensions.Caching.Distributed;
using Smakownia.Basket.Domain.Models;
using Smakownia.Basket.Domain.Repositories;
using System.Text.Json;

namespace Smakownia.Basket.Infrastructure.Repositories;

public class BasketsRepository : IBasketsRepository
{
    private readonly IDistributedCache _distributedCache;
    private readonly JsonSerializerOptions _jsonOptions;

    public BasketsRepository(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
        _jsonOptions = new() { PropertyNameCaseInsensitive = true };
    }

    public async Task<BasketModel> GetAsync(string key, CancellationToken cancellationToken = default)
    {
        var jsonBasket = await _distributedCache.GetStringAsync(key, cancellationToken);

        if (jsonBasket is null)
            return await SetEmptyAsync(key, cancellationToken);

        var basket = JsonSerializer.Deserialize<BasketModel>(jsonBasket, _jsonOptions);

        if (basket is null)
            return await SetEmptyAsync(key, cancellationToken);

        return basket;
    }

    public async Task<BasketModel> SetAsync(string key,
                                            BasketModel basket,
                                            CancellationToken cancellationToken = default)
    {
        var jsonBasket = JsonSerializer.Serialize(basket, _jsonOptions);

        await _distributedCache.SetStringAsync(key, jsonBasket, cancellationToken);

        return basket;
    }

    private async Task<BasketModel> SetEmptyAsync(string key, CancellationToken cancellationToken = default) 
    {
        return await SetAsync(key, new(), cancellationToken);
    }
}
