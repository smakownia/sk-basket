using Smakownia.Basket.Application.Clients;
using Smakownia.Basket.Application.Models;
using Smakownia.Basket.Infrastructure.Exceptions;
using System.Net.Http.Json;
using System.Text.Json;

namespace Smakownia.Basket.Infrastructure.Clients;

public class ProductsClient : IProductsClient
{
    private readonly HttpClient _httpClient;

    public ProductsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"/api/v1/products/{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new ProductNotFoundException(id);
        }

        var product = await response.Content.ReadFromJsonAsync<Product>(
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(id);
        }

        return product;
    }
}
