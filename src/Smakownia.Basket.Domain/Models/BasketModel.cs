using System.ComponentModel.DataAnnotations;

namespace Smakownia.Basket.Domain.Models;

public class BasketModel
{
    [Required]
    public IEnumerable<BasketItem> Items { get; set; } = new List<BasketItem>();
}
