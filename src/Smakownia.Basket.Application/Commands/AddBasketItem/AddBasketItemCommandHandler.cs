using MediatR;
using Smakownia.Basket.Application.Clients;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Entities;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Commands.AddBasketItem;

public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommand, BasketEntity>
{
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;
    private readonly IProductsClient _productsClient;

    public AddBasketItemCommandHandler(IBasketIdentityService basketIdentityService,
                                       IBasketsRepository basketsRepository,
                                       IProductsClient productsClient)
    {
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
        _productsClient = productsClient;
    }

    public async Task<BasketEntity> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        await _productsClient.GetByIdAsync(request.Id);

        var basketId = _basketIdentityService.GetId();
        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        basket.AddItem(request.Id, request.Quantity);

        return await _basketsRepository.SetAsync(basket, cancellationToken);
    }
}
