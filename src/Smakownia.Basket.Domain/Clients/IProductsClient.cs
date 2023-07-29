namespace Smakownia.Basket.Application.Clients;

public interface IProductsClient
{
    Task GetByIdAsync(Guid id);
}
