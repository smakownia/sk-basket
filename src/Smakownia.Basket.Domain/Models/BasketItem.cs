using System.ComponentModel.DataAnnotations;

namespace Smakownia.Basket.Domain.Models;

public record BasketItem
{
    [Required]
    public Guid ProductId { get; init; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; init; }
}
