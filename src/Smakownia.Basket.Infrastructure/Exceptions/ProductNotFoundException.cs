using Smakownia.Basket.Domain.Exceptions;

namespace Smakownia.Basket.Infrastructure.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id) : base($"Product with id: '{id}' not found"){}
}
