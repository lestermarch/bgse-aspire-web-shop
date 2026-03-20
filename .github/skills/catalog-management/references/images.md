# Product Images

Conventions and procedures for managing product images in the Brave Goose Skate Emporium.

---

## Current State

The storefront currently uses **placeholder icons** (⚔ sword emoji) instead of real images. The `product-image-placeholder` CSS class renders a gradient background with the icon centred. This is intentional for the initial build — images are added incrementally.

---

## Image Conventions

| Property | Value |
|---|---|
| **Location** | `BraveGoose.Web/wwwroot/images/products/` |
| **Format** | JPEG (`.jpg`) preferred; PNG (`.png`) for transparency |
| **Naming** | Kebab-case slug matching the product name |
| **Recommended size** | 800×800px (square) or 800×600px (4:3) |
| **Max file size** | Keep under 200KB for performance |
| **URL pattern** | `/images/products/<slug>.jpg` |

### Slug examples

| Product Name | Image Filename |
|---|---|
| The Lancelot | `the-lancelot.jpg` |
| Iron Gauntlet 149mm | `iron-gauntlet-149mm.jpg` |
| Shield Wall 8.25" | `shield-wall-825.jpg` |
| House Crest Tee | `house-crest-tee.jpg` |
| Heraldic Socks Pack | `heraldic-socks-pack.jpg` |

---

## Adding an Image for an Existing Product

### Step 1 — Place the image file

Copy the image to `BraveGoose.Web/wwwroot/images/products/<slug>.jpg`.

Create the `images/products/` directory if it doesn't exist yet:

```bash
mkdir -p BraveGoose.Web/wwwroot/images/products
```

### Step 2 — Verify the ImageUrl

Check that the product's `ImageUrl` in `CatalogStore.cs` matches the filename:

```csharp
ImageUrl = "/images/products/<slug>.jpg"
```

### Step 3 — Update the Razor templates to use real images

The placeholder system needs to be replaced with actual `<img>` tags when images are available. This is a one-time migration:

**In `Home.razor`, `Catalog.razor`, and `ProductDetail.razor`**, replace the placeholder div:

```html
<!-- Before (placeholder) -->
<div class="product-image-placeholder">
    <span>⚔</span>
</div>

<!-- After (real image with fallback) -->
<div class="product-image">
    <img src="@product.ImageUrl" alt="@product.Name" loading="lazy" />
</div>
```

**Add supporting CSS** in `app.css`:

```css
.product-image {
    height: 220px;
    overflow: hidden;
    display: flex;
    align-items: center;
    justify-content: center;
    background: var(--color-offwhite);
}

.product-image img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}

.product-image.large {
    height: 400px;
}
```

### Step 4 — Build and verify

```bash
dotnet build BraveGoose.sln
```

---

## Replacing an Image

1. Replace the file at `BraveGoose.Web/wwwroot/images/products/<slug>.jpg`
2. Keep the same filename — no code changes needed
3. If the browser caches the old image, a hard refresh (Ctrl+Shift+R) will clear it

---

## Removing an Image

1. Delete the file from `BraveGoose.Web/wwwroot/images/products/`
2. Either:
   - Revert the template to use the placeholder div, **or**
   - Leave the `<img>` tag (it will show a broken image — not ideal)
3. Recommendation: keep the placeholder system as a fallback for missing images

---

## Brand Photography Guidelines

When sourcing or creating product images, maintain the premium BGSE aesthetic:

- **Background:** Clean, neutral (off-white, light grey, or navy gradient)
- **Lighting:** Bright, even, studio-style — avoid harsh shadows
- **Composition:** Product centred, generous padding
- **Style:** Think premium fashion lookbook, not grungy skate catalogue
- **Consistency:** All product images should feel like they belong in the same collection

Avoid:
- Busy or cluttered backgrounds
- Heavy filters or colour grading
- Low-resolution or blurry images
- Inconsistent aspect ratios within a category
