---
name: catalog-management
description: 'Catalog management skill for the Brave Goose Skate Emporium webstore. Use when the user asks to add, update, remove, or manage products, categories, collections, images, or featured items in the store catalog.'
---

# Catalog Management — Brave Goose Skate Emporium

This skill provides step-by-step procedures for day-to-day management of the BGSE product catalog. It covers adding products, updating existing items, managing images, and modifying categories and collections.

> **Key principle:** The catalog is currently seed-data driven — all products live in `CatalogStore.cs`. Changes are code changes committed to the repo.

Detailed procedures live in the `references/` folder — load on demand.

---

## References

| Reference | When to load |
|---|---|
| [Product Operations](references/product-operations.md) | Adding, updating, or removing a product |
| [Categories & Collections](references/categories-collections.md) | Adding or modifying categories, collections, or navigation |
| [Images](references/images.md) | Adding, replacing, or managing product images |
| [Brand Voice](references/brand-voice.md) | Writing product descriptions, taglines, and copy |
| [GitHub Workflow](references/github-workflow.md) | Issue-to-PR pipeline, agent instructions, review process |

---

## 1. Architecture Overview

### Data flow

```
CatalogStore.cs (seed data) → API endpoints → CatalogApiClient → Blazor pages
```

### Key files

| File | Purpose |
|---|---|
| `BraveGoose.ApiService/Models/Product.cs` | Product data model |
| `BraveGoose.ApiService/Data/CatalogStore.cs` | All product data (in-memory seed store) |
| `BraveGoose.ApiService/Program.cs` | API endpoints (`/api/products/*`) |
| `BraveGoose.Web/CatalogApiClient.cs` | Frontend HTTP client + `Product` record |
| `BraveGoose.Web/Components/Pages/Home.razor` | Homepage (featured products, category cards) |
| `BraveGoose.Web/Components/Pages/Catalog.razor` | Category browsing page (category taglines) |
| `BraveGoose.Web/Components/Pages/ProductDetail.razor` | Single product detail page |
| `BraveGoose.Web/Components/Layout/MainLayout.razor` | Site header navigation (category links) |
| `BraveGoose.Web/wwwroot/app.css` | Design system (category card colours, etc.) |
| `BraveGoose.Web/wwwroot/images/products/` | Product image files |

### Product model

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }      // "Boards", "Trucks", "Wheels", "Apparel"
    public string Collection { get; set; }    // "Knight's Choice", "House Colours", "The Quad", "Crest Collection"
    public string ImageUrl { get; set; }      // e.g. "/images/products/the-lancelot.jpg"
    public bool IsFeatured { get; set; }
}
```

### Current categories

| Category | Description |
|---|---|
| Boards | Decks and complete boards |
| Trucks | Axle and baseplate hardware |
| Wheels | Urethane wheels (various durometers) |
| Apparel | Clothing and accessories |

### Current collections

| Collection | Theme |
|---|---|
| Knight's Choice | Premium line — the best of the best |
| House Colours | Signature branded items |
| The Quad | Park and courtyard essentials |
| Crest Collection | Heritage / timeless pieces |

---

## 2. Quick Reference — Common Tasks

### Add a product

1. Determine the next available `Id` in `CatalogStore.cs` (currently 1–16)
2. Add a new `Product` entry to the list in the appropriate category section
3. Follow the [Brand Voice](references/brand-voice.md) guide for the description
4. Set `ImageUrl` to `/images/products/{slug}.jpg` — see [Images](references/images.md)
5. Set `IsFeatured = true` if it should appear on the homepage
6. Build and verify: `dotnet build BraveGoose.sln`

### Update a product

1. Find the product by `Id` or `Name` in `CatalogStore.cs`
2. Edit the relevant fields
3. If changing `Category`, check the [Categories & Collections](references/categories-collections.md) guide
4. Build and verify

### Toggle featured status

1. Find the product in `CatalogStore.cs`
2. Set `IsFeatured = true` or `false`
3. Featured products appear on the homepage in the "Featured Gear" section

### Add a product image

See [Images](references/images.md) for the full procedure and conventions.

---

## 3. Important Constraints

- **IDs must be unique** — always check the highest existing ID before assigning a new one
- **Category values are case-sensitive** in the seed data but the API filters case-insensitively
- **The frontend `Product` record** in `CatalogApiClient.cs` must match the API model — if you add fields to the API model, add them to the frontend record too
- **Prices use `decimal`** with the `m` suffix (e.g., `149.99m`)
- **Currency is GBP (£)** — the frontend formats with `£` prefix
- **Build after every change** — `dotnet build BraveGoose.sln`
