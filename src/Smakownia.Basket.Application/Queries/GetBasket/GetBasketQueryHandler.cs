using MediatR;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Entities;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Queries.GetBasket;

public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketEntity>
{
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;

    public GetBasketQueryHandler(IBasketIdentityService basketIdentityService,
                                 IBasketsRepository basketsRepository)
    {
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketEntity> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basketId = _basketIdentityService.GetId();

        return await _basketsRepository.GetAsync(basketId, cancellationToken);
    }
}
