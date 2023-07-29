using Smakownia.Basket.Application.Clients;
using Smakownia.Basket.Infrastructure.Exceptions;

namespace Smakownia.Basket.Infrastructure.Clients;

public class ProductsClient : IProductsClient
{
    private readonly HttpClient _httpClient;

    public ProductsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"/api/v1/products/{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new ProductNotFoundException(id);
        }
    }
}
