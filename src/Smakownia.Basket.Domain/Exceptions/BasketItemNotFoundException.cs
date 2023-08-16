namespace Smakownia.Basket.Domain.Exceptions;

public class BasketItemNotFoundException : NotFoundException
{
    public BasketItemNotFoundException(Guid id) : base($"Basket item with id: '{id}' not found") { }
}
