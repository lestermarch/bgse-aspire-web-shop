using System.Net.Http.Json;

namespace BraveGoose.Tests;

public class CatalogApiTests
{
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(60);

    [Fact]
    public async Task ApiService_ReturnsHealthy()
    {
        var cancellationToken = CancellationToken.None;
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.BraveGoose_AppHost>(cancellationToken);

        appHost.Services.ConfigureHttpClientDefaults(http =>
            http.AddStandardResilienceHandler());

        await using var app = await appHost.BuildAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);
        await app.StartAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var client = app.CreateHttpClient("apiservice");
        await app.ResourceNotifications
            .WaitForResourceHealthyAsync("apiservice", cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var response = await client.GetAsync("/health", cancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task WebFrontend_ReturnsHealthy()
    {
        var cancellationToken = CancellationToken.None;
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.BraveGoose_AppHost>(cancellationToken);

        appHost.Services.ConfigureHttpClientDefaults(http =>
            http.AddStandardResilienceHandler());

        await using var app = await appHost.BuildAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);
        await app.StartAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var client = app.CreateHttpClient("webfrontend");
        await app.ResourceNotifications
            .WaitForResourceHealthyAsync("webfrontend", cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var response = await client.GetAsync("/health", cancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetAllProducts_Returns16Products()
    {
        var cancellationToken = CancellationToken.None;
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.BraveGoose_AppHost>(cancellationToken);

        appHost.Services.ConfigureHttpClientDefaults(http =>
            http.AddStandardResilienceHandler());

        await using var app = await appHost.BuildAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);
        await app.StartAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var client = app.CreateHttpClient("apiservice");
        await app.ResourceNotifications
            .WaitForResourceHealthyAsync("apiservice", cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var products = await client.GetFromJsonAsync<Product[]>(
            "/api/products", cancellationToken);

        Assert.NotNull(products);
        Assert.Equal(16, products.Length);
    }

    [Fact]
    public async Task GetFeaturedProducts_ReturnsOnlyFeatured()
    {
        var cancellationToken = CancellationToken.None;
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.BraveGoose_AppHost>(cancellationToken);

        appHost.Services.ConfigureHttpClientDefaults(http =>
            http.AddStandardResilienceHandler());

        await using var app = await appHost.BuildAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);
        await app.StartAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var client = app.CreateHttpClient("apiservice");
        await app.ResourceNotifications
            .WaitForResourceHealthyAsync("apiservice", cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var products = await client.GetFromJsonAsync<Product[]>(
            "/api/products/featured", cancellationToken);

        Assert.NotNull(products);
        Assert.NotEmpty(products);
        Assert.All(products, p => Assert.True(p.IsFeatured));
    }

    [Theory]
    [InlineData("Boards", 4)]
    [InlineData("Trucks", 4)]
    [InlineData("Wheels", 4)]
    [InlineData("Apparel", 4)]
    public async Task GetProductsByCategory_ReturnsCorrectCount(string category, int expectedCount)
    {
        var cancellationToken = CancellationToken.None;
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.BraveGoose_AppHost>(cancellationToken);

        appHost.Services.ConfigureHttpClientDefaults(http =>
            http.AddStandardResilienceHandler());

        await using var app = await appHost.BuildAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);
        await app.StartAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var client = app.CreateHttpClient("apiservice");
        await app.ResourceNotifications
            .WaitForResourceHealthyAsync("apiservice", cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var products = await client.GetFromJsonAsync<Product[]>(
            $"/api/products/category/{category}", cancellationToken);

        Assert.NotNull(products);
        Assert.Equal(expectedCount, products.Length);
        Assert.All(products, p =>
            Assert.Equal(category, p.Category, StringComparer.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task GetProductById_ReturnsProduct()
    {
        var cancellationToken = CancellationToken.None;
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.BraveGoose_AppHost>(cancellationToken);

        appHost.Services.ConfigureHttpClientDefaults(http =>
            http.AddStandardResilienceHandler());

        await using var app = await appHost.BuildAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);
        await app.StartAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var client = app.CreateHttpClient("apiservice");
        await app.ResourceNotifications
            .WaitForResourceHealthyAsync("apiservice", cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var product = await client.GetFromJsonAsync<Product>(
            "/api/products/1", cancellationToken);

        Assert.NotNull(product);
        Assert.Equal(1, product.Id);
        Assert.Equal("The Lancelot", product.Name);
        Assert.Equal("Boards", product.Category);
    }

    [Fact]
    public async Task GetProductById_InvalidId_Returns404()
    {
        var cancellationToken = CancellationToken.None;
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.BraveGoose_AppHost>(cancellationToken);

        appHost.Services.ConfigureHttpClientDefaults(http =>
            http.AddStandardResilienceHandler());

        await using var app = await appHost.BuildAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);
        await app.StartAsync(cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var client = app.CreateHttpClient("apiservice");
        await app.ResourceNotifications
            .WaitForResourceHealthyAsync("apiservice", cancellationToken)
            .WaitAsync(DefaultTimeout, cancellationToken);

        var response = await client.GetAsync("/api/products/9999", cancellationToken);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    private record Product(
        int Id,
        string Name,
        string Description,
        decimal Price,
        string Category,
        string Collection,
        string ImageUrl,
        bool IsFeatured);
}
