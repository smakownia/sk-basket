using MediatR;
using Smakownia.Basket.Domain.Entities;

namespace Smakownia.Basket.Application.Commands.RemoveBasketItem;

public sealed record RemoveBasketItemCommand(Guid Id) : IRequest<BasketEntity>;
