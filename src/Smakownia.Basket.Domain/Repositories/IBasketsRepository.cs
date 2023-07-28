using Smakownia.Basket.Domain.Entities;

namespace Smakownia.Basket.Domain.Repositories;

public interface IBasketsRepository
{
    Task<BasketEntity> GetAsync(Guid key, CancellationToken cancellationToken);
    Task<BasketEntity> SetAsync(BasketEntity basket, CancellationToken cancellationToken);
}
