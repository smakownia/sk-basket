using MediatR;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Models;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Commands.RemoveBasketItem;

public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommand, BasketModel>
{
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;

    public RemoveBasketItemCommandHandler(IBasketIdentityService basketIdentityService, IBasketsRepository basketsRepository)
    {
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketModel> Handle(RemoveBasketItemCommand request, CancellationToken cancellationToken)
    {
        var basketId = _basketIdentityService.GetId();

        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        basket.RemoveItem(request.Id);

        return await _basketsRepository.SetAsync(basket, cancellationToken);
    }
}
