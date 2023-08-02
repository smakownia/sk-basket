using AutoMapper;
using MediatR;
using Smakownia.Basket.Application.Dtos;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Commands.RemoveBasketItem;

public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommand, BasketDto>
{
    private readonly IMapper _mapper;
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;

    public RemoveBasketItemCommandHandler(IMapper mapper,
                                          IBasketIdentityService basketIdentityService,
                                          IBasketsRepository basketsRepository)
    {
        _mapper = mapper;
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketDto> Handle(RemoveBasketItemCommand request, CancellationToken cancellationToken)
    {
        var basketId = _basketIdentityService.GetId();
        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        basket.RemoveItem(request.Id);

        await _basketsRepository.SetAsync(basket, cancellationToken);

        return _mapper.Map<BasketDto>(basket);
    }
}
