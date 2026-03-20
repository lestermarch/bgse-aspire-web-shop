# Product Operations

Step-by-step procedures for adding, updating, and removing products from the Brave Goose Skate Emporium catalog.

---

## Adding a New Product

### Step 1 — Determine the ID

Check the last product ID in `BraveGoose.ApiService/Data/CatalogStore.cs` and increment by 1.

### Step 2 — Add the entry to CatalogStore.cs

Insert a new `Product` block in the appropriate category section (products are grouped by category with comments). Follow this template:

```csharp
new Product
{
    Id = <next-id>,
    Name = "<product-name>",
    Description = "<1-2 sentences in brand voice — see brand-voice.md>",
    Price = <price>m,
    Category = "<Boards|Trucks|Wheels|Apparel>",
    Collection = "<Knight's Choice|House Colours|The Quad|Crest Collection>",
    ImageUrl = "/images/products/<slug>.jpg",
    IsFeatured = <true|false>
},
```

### Step 3 — Generate the image slug

The `ImageUrl` slug should be a kebab-case version of the product name:
- "The Lancelot" → `the-lancelot`
- "Iron Gauntlet 149mm" → `iron-gauntlet-149mm`
- "Shield Wall 8.25\"" → `shield-wall-825`

Convention: `/images/products/<slug>.jpg`

### Step 4 — Build and verify

```bash
dotnet build BraveGoose.sln
```

### Step 5 — Commit

Use a descriptive commit message:
```
Add product: <product-name> (<category>)
```

---

## Updating an Existing Product

### Locate the product

Search `CatalogStore.cs` for the product by `Id` or `Name`.

### Editable fields

| Field | Notes |
|---|---|
| `Name` | Update the `ImageUrl` slug if the name changes |
| `Description` | Must follow brand voice guidelines |
| `Price` | Use `decimal` with `m` suffix |
| `Category` | See categories-collections.md — may require nav/CSS updates |
| `Collection` | Must be one of the four existing collections, or create a new one |
| `ImageUrl` | Update if name changes or image is replaced |
| `IsFeatured` | Toggle homepage visibility |

### If changing the product name

1. Update `Name` in `CatalogStore.cs`
2. Update `ImageUrl` to match the new slug
3. Rename the image file in `wwwroot/images/products/` if it exists

### Commit message

```
Update product: <product-name> — <what changed>
```

---

## Removing a Product

### Step 1 — Remove from CatalogStore.cs

Delete the entire `new Product { ... }` block for the product.

### Step 2 — Clean up the image

Delete the corresponding image file from `BraveGoose.Web/wwwroot/images/products/` if it exists.

### Step 3 — Verify no gaps cause issues

Product IDs do **not** need to be contiguous — gaps are fine. Do not renumber other products.

### Step 4 — Build and verify

```bash
dotnet build BraveGoose.sln
```

### Commit message

```
Remove product: <product-name>
```

---

## Bulk Operations

When adding or updating multiple products at once:

1. Make all changes to `CatalogStore.cs` in a single edit
2. Ensure all IDs are unique
3. Keep products grouped by category (Boards, Trucks, Wheels, Apparel) with comment headers
4. Build once at the end
5. Use a summary commit message:

```
Add 3 products to Wheels category

- Jousting 60mm 82a (Crest Collection)
- Drawbridge 55mm 97a (The Quad)
- Tournament 53mm 101a (Knight's Choice)
```
