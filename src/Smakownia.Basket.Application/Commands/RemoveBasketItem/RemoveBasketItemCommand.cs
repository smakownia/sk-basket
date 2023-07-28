using MediatR;
using Smakownia.Basket.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Basket.Application.Commands.RemoveBasketItem;

public sealed record RemoveBasketItemCommand : IRequest<BasketModel>
{
    public RemoveBasketItemCommand(Guid id)
    {
        Id = id;
    }

    [Required]
    public Guid Id { get; init; }
}
