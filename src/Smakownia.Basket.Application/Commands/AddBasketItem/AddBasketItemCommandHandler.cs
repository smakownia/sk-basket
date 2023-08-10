using AutoMapper;
using MediatR;
using Smakownia.Basket.Application.Clients;
using Smakownia.Basket.Application.Dtos;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Commands.AddBasketItem;

public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommand, BasketDto>
{
    private readonly IMapper _mapper;
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;
    private readonly IProductsClient _productsClient;

    public AddBasketItemCommandHandler(IMapper mapper,
                                       IBasketIdentityService basketIdentityService,
                                       IBasketsRepository basketsRepository,
                                       IProductsClient productsClient)
    {
        _mapper = mapper;
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
        _productsClient = productsClient;
    }

    public async Task<BasketDto> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsClient.GetByIdAsync(request.Id, cancellationToken);

        var basketId = _basketIdentityService.GetId();
        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        basket.AddItem(product.Id, product.ImageUrl, product.Name, product.Description, product.Price.Raw, request.Quantity);

        await _basketsRepository.SetAsync(basket, cancellationToken);

        return _mapper.Map<BasketDto>(basket);
    }
}
