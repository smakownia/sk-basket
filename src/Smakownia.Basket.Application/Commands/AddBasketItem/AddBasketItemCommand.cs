using MediatR;
using Smakownia.Basket.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Basket.Application.Commands.AddBasketItem;

public sealed record AddBasketItemCommand : IRequest<BasketEntity>
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
