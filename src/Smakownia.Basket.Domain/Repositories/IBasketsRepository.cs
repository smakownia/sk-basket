using Smakownia.Basket.Domain.Models;

namespace Smakownia.Basket.Domain.Repositories;

public interface IBasketsRepository
{
    Task<BasketModel> GetAsync(Guid key, CancellationToken cancellationToken);
    Task<BasketModel> SetAsync(BasketModel basket, CancellationToken cancellationToken);
}
