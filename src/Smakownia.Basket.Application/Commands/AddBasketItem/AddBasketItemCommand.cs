using MediatR;
using Smakownia.Basket.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Basket.Application.Commands.AddBasketItem;

public sealed record AddBasketItemCommand : IRequest<BasketDto>
{
    public AddBasketItemCommand(Guid id, int quantity)
    {
        Id = id;
        Quantity = quantity;
    }

    [Required]
    public Guid Id { get; init; }

    [Required]
    [Range(1, 999)]
    public int Quantity { get; init; }
}
