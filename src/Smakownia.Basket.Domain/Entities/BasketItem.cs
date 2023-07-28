using Smakownia.Basket.Domain.Snapshots;

namespace Smakownia.Basket.Domain.Entities;

public class BasketItem
{
    internal BasketItem(Guid id, int quantity)
    {
        Id = id;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public int Quantity { get; private set; }

    internal void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }

    internal void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public BasketItemSnapshot ToSnapshot()
    {
        return new()
        {
            Id = Id,
            Quantity = Quantity
        };
    }
}
