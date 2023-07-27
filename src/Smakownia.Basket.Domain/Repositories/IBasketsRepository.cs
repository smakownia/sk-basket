using Smakownia.Basket.Domain.Models;

namespace Smakownia.Basket.Domain.Repositories;

public interface IBasketsRepository
{
    Task<BasketModel> GetAsync(string key, CancellationToken cancellationToken = default);
    Task<BasketModel> SetAsync(string key, BasketModel basket, CancellationToken cancellationToken = default);
}
