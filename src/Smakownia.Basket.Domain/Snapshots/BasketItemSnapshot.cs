namespace Smakownia.Basket.Domain.Snapshots;

public class BasketItemSnapshot
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public long Price { get; set; }
    public int Quantity { get; set; }
}
