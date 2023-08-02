namespace Smakownia.Basket.Application.Dtos;

public class BasketDto
{
    public Guid Id { get; set; }
    public IEnumerable<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    public PriceDto TotalPrice { get; set; } = new();
    public int TotalItems { get; set; }
}
