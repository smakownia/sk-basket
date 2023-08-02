using AutoMapper;
using MediatR;
using Smakownia.Basket.Application.Dtos;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Queries.GetBasket;

public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketDto>
{
    private readonly IMapper _mapper;
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;

    public GetBasketQueryHandler(IMapper mapper,
                                 IBasketIdentityService basketIdentityService,
                                 IBasketsRepository basketsRepository)
    {
        _mapper = mapper;
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketDto> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basketId = _basketIdentityService.GetId();

        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        return _mapper.Map<BasketDto>(basket);
    }
}
