namespace Smakownia.Basket.Application.Dtos;

public class BasketItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriceDto Price { get; set; } = new();
    public int Quantity { get; set; }
    public PriceDto TotalPrice { get; set; } = new();
}
