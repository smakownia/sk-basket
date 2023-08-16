using MediatR;
using Smakownia.Basket.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Basket.Application.Commands.UpdateBasketItem;

public sealed record UpdateBasketItemCommand : IRequest<BasketDto>
{
    public UpdateBasketItemCommand(Guid id, int quantity)
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
