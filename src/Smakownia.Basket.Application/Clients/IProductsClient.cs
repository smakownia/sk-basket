using Smakownia.Basket.Application.Models;

namespace Smakownia.Basket.Application.Clients;

public interface IProductsClient
{
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
