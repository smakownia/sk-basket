﻿using MediatR;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Models;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Basket.Application.Commands.UpdateBasketItem;

public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommand, BasketModel>
{
    private readonly IBasketIdentityService _basketIdentityService;
    private readonly IBasketsRepository _basketsRepository;

    public UpdateBasketItemCommandHandler(IBasketIdentityService basketIdentityService,
                                          IBasketsRepository basketsRepository)
    {
        _basketIdentityService = basketIdentityService;
        _basketsRepository = basketsRepository;
    }

    public async Task<BasketModel> Handle(UpdateBasketItemCommand request, CancellationToken cancellationToken)
    {
        var basketId = _basketIdentityService.GetId();

        var basket = await _basketsRepository.GetAsync(basketId, cancellationToken);

        basket.UpdateItem(request.Id, request.Quantity);

        return await _basketsRepository.SetAsync(basket, cancellationToken);
    }
}
