using Smakownia.Basket.Application.Providers;
using Smakownia.Basket.Domain.Models;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Services;

public class BasketsService : IBasketsService
{
    private readonly IBasketIdentityProvider _basketIdentityProvider;
    private readonly IBasketsRepository _basketsRepository;

    public BasketsService(IBasketIdentityProvider basketIdentityProvider,
                          IBasketsRepository basketsRepository)
    {
        _basketIdentityProvider = basketIdentityProvider;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketModel> GetAsync(CancellationToken cancellationToken = default)
    {
        var basketId = _basketIdentityProvider.GetBasketId();

        return await _basketsRepository.GetAsync(basketId, cancellationToken);
    }

    public async Task<BasketModel> SetAsync(BasketModel basket, CancellationToken cancellationToken = default)
    {
        var basketId = _basketIdentityProvider.GetBasketId();

        return await _basketsRepository.SetAsync(basketId, basket, cancellationToken);
    }
}
