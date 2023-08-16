using MediatR;
using Smakownia.Basket.Application.Dtos;

namespace Smakownia.Basket.Application.Commands.AddBasketItem;

public sealed record AddBasketItemCommand(Guid Id,
                                          string ImageUrl,
                                          string Name,
                                          string? Description,
                                          long Price,
                                          int Quantity) : IRequest<BasketDto>;
