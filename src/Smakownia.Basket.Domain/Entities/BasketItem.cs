using Smakownia.Basket.Domain.Snapshots;

namespace Smakownia.Basket.Domain.Entities;

public class BasketItem
{
    public BasketItem(Guid id, string imageUrl, string name, string? description, long price, int quantity)
    {
        Id = id;
        ImageUrl = imageUrl;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public string ImageUrl { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public long Price { get; private set; }
    public int Quantity { get; private set; }

    internal void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    internal void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }

    public BasketItemSnapshot ToSnapshot()
    {
        return new()
        {
            Id = Id,
            ImageUrl = ImageUrl,
            Name = Name,
            Description = Description,
            Price = Price,
            Quantity = Quantity
        };
    }
}
