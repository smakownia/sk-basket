using Smakownia.Basket.Domain.Models;

namespace Smakownia.Basket.Application.Services;
public interface IBasketsService
{
    Task<BasketModel> GetAsync(CancellationToken cancellationToken = default);
    Task<BasketModel> SetAsync(BasketModel basket, CancellationToken cancellationToken = default);
}