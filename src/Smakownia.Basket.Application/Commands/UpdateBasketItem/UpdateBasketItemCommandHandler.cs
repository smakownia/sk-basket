using AutoMapper;
using MediatR;
using Smakownia.Basket.Application.Dtos;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Commands.UpdateBasketItem;

public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommand, BasketDto>
{
    private readonly IMapper _mapper;
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;

    public UpdateBasketItemCommandHandler(IMapper mapper,
                                          IBasketIdentityService basketIdentityService,
                                          IBasketsRepository basketsRepository)
    {
        _mapper = mapper;
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketDto> Handle(UpdateBasketItemCommand request, CancellationToken cancellationToken)
    {
        var basketId = _basketIdentityService.GetId();
        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        basket.UpdateItem(request.Id, request.Quantity);

        await _basketsRepository.SetAsync(basket, cancellationToken);

        return _mapper.Map<BasketDto>(basket);
    }
}
