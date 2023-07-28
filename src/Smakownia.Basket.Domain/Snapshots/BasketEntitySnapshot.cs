namespace Smakownia.Basket.Domain.Snapshots;

public class BasketEntitySnapshot
{
    public Guid Id { get; set; }
    public IEnumerable<BasketItemSnapshot> Items { get; set; }
        = new List<BasketItemSnapshot>();
}
