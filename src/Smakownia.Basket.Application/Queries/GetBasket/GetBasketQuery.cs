using MediatR;
using Smakownia.Basket.Domain.Entities;

namespace Smakownia.Basket.Application.Queries.GetBasket;

public sealed record GetBasketQuery : IRequest<BasketEntity>;
