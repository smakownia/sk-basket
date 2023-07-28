using Microsoft.Extensions.Caching.Distributed;
using Smakownia.Basket.Domain.Models;
using Smakownia.Basket.Domain.Repositories;
using Smakownia.Basket.Domain.Snapshots;
using System.Text.Json;

namespace Smakownia.Basket.Infrastructure.Repositories;

public class BasketsRepository : IBasketsRepository
{
    private readonly IDistributedCache _distributedCache;

    public BasketsRepository(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<BasketModel> GetAsync(Guid key, CancellationToken cancellationToken)
    {
        var basketJson = await _distributedCache.GetStringAsync(key.ToString(), cancellationToken);

        if (string.IsNullOrEmpty(basketJson))
        {
            return await SetAsync(new(key), cancellationToken);
        }

        var basketSnapshot = JsonSerializer.Deserialize<BasketModelSnapshot>(basketJson);

        if (basketSnapshot is null)
        {
            return await SetAsync(new(key), cancellationToken);
        }

        return BasketModel.Restore(basketSnapshot);
    }

    public async Task<BasketModel> SetAsync(BasketModel basket, CancellationToken cancellationToken)
    {
        var basketJson = JsonSerializer.Serialize(basket.ToSnapshot());

        await _distributedCache.SetStringAsync(basket.Id.ToString(), basketJson, cancellationToken);

        return basket;
    }
}
