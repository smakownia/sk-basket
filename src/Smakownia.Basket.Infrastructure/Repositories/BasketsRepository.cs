using Smakownia.Basket.Domain.Entities;
using Smakownia.Basket.Domain.Repositories;
using Smakownia.Basket.Domain.Snapshots;
using StackExchange.Redis;
using System.Text.Json;

namespace Smakownia.Basket.Infrastructure.Repositories;

public class BasketsRepository : IBasketsRepository
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public BasketsRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = redis.GetDatabase();
    }

    public IEnumerable<Guid> GetKeys()
    {
        return GetServer().Keys().Select(k => Guid.Parse(k));
    }

    public async Task<BasketEntity> GetAsync(Guid key)
    {
        var basketJson = await _database.StringGetAsync(key.ToString());

        if (string.IsNullOrEmpty(basketJson))
        {
            return await SetAsync(new(key));
        }

        var basketSnapshot = JsonSerializer.Deserialize<BasketEntitySnapshot>(basketJson);

        if (basketSnapshot is null)
        {
            return await SetAsync(new(key));
        }

        return BasketEntity.Restore(basketSnapshot);
    }

    public async Task<BasketEntity> SetAsync(BasketEntity basket)
    {
        var basketJson = JsonSerializer.Serialize(basket.ToSnapshot());

        await _database.StringSetAsync(basket.Id.ToString(), basketJson);

        return basket;
    }

    private IServer GetServer()
    {
        var endpoint = _redis.GetEndPoints().First();

        return _redis.GetServer(endpoint);
    }
}
