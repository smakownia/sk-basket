using MediatR;
using Smakownia.Basket.Application.Dtos;

namespace Smakownia.Basket.Application.Queries.GetBasket;

public sealed record GetBasketQuery : IRequest<BasketDto>;
