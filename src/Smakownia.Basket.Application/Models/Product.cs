namespace Smakownia.Basket.Application.Models;

public class Product
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ProductPrice Price { get; set; } = new();
}
