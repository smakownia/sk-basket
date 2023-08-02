using MediatR;
using Smakownia.Basket.Application.Dtos;

namespace Smakownia.Basket.Application.Commands.RemoveBasketItem;

public sealed record RemoveBasketItemCommand(Guid Id) : IRequest<BasketDto>;
