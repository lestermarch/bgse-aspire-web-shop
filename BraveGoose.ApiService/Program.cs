using BraveGoose.ApiService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "Brave Goose Skate Emporium Catalog API");

app.MapGet("/api/products", () => CatalogStore.GetProducts())
    .WithName("GetAllProducts");

app.MapGet("/api/products/featured", () =>
        CatalogStore.GetProducts().Where(p => p.IsFeatured))
    .WithName("GetFeaturedProducts");

app.MapGet("/api/products/category/{category}", (string category) =>
        CatalogStore.GetProducts()
            .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)))
    .WithName("GetProductsByCategory");

app.MapGet("/api/products/{id:int}", (int id) =>
    {
        var product = CatalogStore.GetProducts().FirstOrDefault(p => p.Id == id);
        return product is not null ? Results.Ok(product) : Results.NotFound();
    })
    .WithName("GetProductById");

app.MapDefaultEndpoints();

app.Run();
