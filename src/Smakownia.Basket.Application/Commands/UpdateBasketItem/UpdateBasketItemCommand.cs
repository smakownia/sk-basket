using MediatR;
using Smakownia.Basket.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Basket.Application.Commands.UpdateBasketItem;

public sealed record UpdateBasketItemCommand : IRequest<BasketModel>
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
