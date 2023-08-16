using Smakownia.Basket.Domain.Entities;

namespace Smakownia.Basket.Domain.Repositories;

public interface IBasketsRepository
{
    IEnumerable<Guid> GetKeys();
    Task<BasketEntity> GetAsync(Guid key);
    Task<BasketEntity> SetAsync(BasketEntity basket);
}
