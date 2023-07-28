using MediatR;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Entities;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Commands.AddBasketItem;

public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommand, BasketEntity>
{
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;

    public AddBasketItemCommandHandler(IBasketIdentityService basketIdentityService,
                                       IBasketsRepository basketsRepository)
    {
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketEntity> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        var basketId = _basketIdentityService.GetId();
        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        basket.AddItem(request.Id, request.Quantity);

        return await _basketsRepository.SetAsync(basket, cancellationToken);
    }
}
