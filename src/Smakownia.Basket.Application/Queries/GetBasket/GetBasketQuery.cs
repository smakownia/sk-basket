using MediatR;
using Smakownia.Basket.Domain.Models;

namespace Smakownia.Basket.Application.Queries.GetBasket;

public sealed record GetBasketQuery : IRequest<BasketModel>;
