using Smakownia.Basket.Domain.Snapshots;

namespace Smakownia.Basket.Domain.Models;

public class BasketModel
{
    private readonly HashSet<BasketItem> _items;

    public BasketModel(Guid id)
    {
        Id = id;
        _items = new();
    }

    public Guid Id { get; private set; }
    public IReadOnlyCollection<BasketItem> Items => _items;

    private BasketItem? GetItemById(Guid id)
    {
        return _items.Where(i => i.Id == id).FirstOrDefault();
    }

    public void AddItem(Guid id, int quantity)
    {
        var existingItem = GetItemById(id);

        if (existingItem is not null)
        {
            existingItem.AddQuantity(quantity);
            return;
        }

        _items.Add(new(id, quantity));
    }

    public void UpdateItem(Guid id, int quantity)
    {
        var item = GetItemById(id);

        if (item is null) return;

        item.SetQuantity(quantity);
    }

    public void RemoveItem(Guid id)
    {
        var item = GetItemById(id);

        if (item is null) return;

        _items.Remove(item);
    }

    public static BasketModel Restore(BasketModelSnapshot snapshot)
    {
        var basket = new BasketModel(snapshot.Id);

        foreach (var item in snapshot.Items)
        {
            basket.AddItem(item.Id, item.Quantity);
        }

        return basket;
    }

    public BasketModelSnapshot ToSnapshot()
    {
        return new()
        {
            Id = Id,
            Items = _items.Select(i => i.ToSnapshot())
        };
    }
}
