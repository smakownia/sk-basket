using AutoMapper;
using MediatR;
using Smakownia.Basket.Application.Dtos;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Commands.AddBasketItem;

public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommand, BasketDto>
{
    private readonly IMapper _mapper;
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;

    public AddBasketItemCommandHandler(IMapper mapper,
                                       IBasketIdentityService basketIdentityService,
                                       IBasketsRepository basketsRepository)
    {
        _mapper = mapper;
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketDto> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        var basketId = _basketIdentityService.GetId();
        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        basket.AddItem(request.Id, request.ImageUrl, request.Name, request.Description, request.Price, request.Quantity);

        await _basketsRepository.SetAsync(basket, cancellationToken);

        return _mapper.Map<BasketDto>(basket);
    }
}
