namespace BraveGoose.Web;

public class CatalogApiClient(HttpClient httpClient)
{
    public async Task<Product[]> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Product[]>("/api/products", cancellationToken) ?? [];
    }

    public async Task<Product[]> GetFeaturedProductsAsync(CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Product[]>("/api/products/featured", cancellationToken) ?? [];
    }

    public async Task<Product[]> GetProductsByCategoryAsync(string category, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Product[]>($"/api/products/category/{category}", cancellationToken) ?? [];
    }

    public async Task<Product?> GetProductAsync(int id, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<Product>($"/api/products/{id}", cancellationToken);
    }
}

public record Product(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string Category,
    string Collection,
    string ImageUrl,
    bool IsFeatured);
