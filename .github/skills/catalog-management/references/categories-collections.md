# Categories & Collections

Procedures for adding or modifying product categories and collections. These are cross-cutting changes that affect multiple files.

---

## Current Categories

| Category | Nav label | CSS class | Tagline (Catalog.razor) |
|---|---|---|---|
| Boards | Boards | `.category-boards` | "The foundation of every noble ride." |
| Trucks | Trucks | `.category-trucks` | "Forged in the fires of the halfpipe." |
| Wheels | Wheels | `.category-wheels` | "Roll with distinction and purpose." |
| Apparel | Apparel | `.category-apparel` | "Wear the crest. Earn the bruises." |

## Current Collections

| Collection | Theme | Used in |
|---|---|---|
| Knight's Choice | Premium line | Products across all categories |
| House Colours | Signature brand items | Products across all categories |
| The Quad | Park / courtyard essentials | Products across all categories |
| Crest Collection | Heritage / timeless | Products across all categories |

---

## Adding a New Category

This is a multi-file change. All 5 steps are required.

### Step 1 — Add products in CatalogStore.cs

Add a new comment section and product entries:

```csharp
// <New Category>
new Product
{
    Id = <next-id>,
    Name = "...",
    ...
    Category = "<NewCategory>",
    ...
},
```

### Step 2 — Add nav link in MainLayout.razor

Add a new `<a>` element in the `<nav class="main-nav">` section:

```html
<a href="/catalog/<NewCategory>"><NewCategory></a>
```

Place it in a logical order (before "About").

### Step 3 — Add category card on Home.razor

Add a new card in the `<div class="category-grid">` section:

```html
<a href="/catalog/<NewCategory>" class="category-card category-<slug>">
    <h3><Display Name></h3>
    <p><Brand-voice tagline></p>
</a>
```

### Step 4 — Add category tagline in Catalog.razor

Add a new case to the `GetCategoryTagline` switch expression:

```csharp
"<NewCategory>" => "<tagline>",
```

### Step 5 — Add CSS for the category card

Add a new gradient class in `wwwroot/app.css` in the category card colours section:

```css
.category-<slug> { background: linear-gradient(135deg, <colour1>, <colour2>); }
```

Use colours from the brand palette or complementary tones:
- Navy: `#0B1B3B` / `#1a3366`
- Burgundy: `#6B1F35` / `#8a2a48`
- Forest Green: `#184A2F` / `#1f6640`
- Gold: `#D9A441`

---

## Adding a New Collection

Collections are simpler — they only affect product data and the About page.

### Step 1 — Use the collection name in CatalogStore.cs

Set `Collection = "<New Collection>"` on the relevant products.

### Step 2 — Add a house card on About.razor

Add a new card in the `<div class="houses-grid">` section:

```html
<div class="house-card house-<slug>">
    <h3><Collection Name></h3>
    <p><1-sentence description></p>
</div>
```

### Step 3 — Add CSS for the house card

Add a background colour in `wwwroot/app.css`:

```css
.house-<slug> { background: <colour-from-palette>; }
```

---

## Renaming a Category

1. Update all product entries in `CatalogStore.cs` — change the `Category` value
2. Update the nav link in `MainLayout.razor`
3. Update the category card `href` and CSS class in `Home.razor`
4. Update the tagline in `Catalog.razor`
5. Update the CSS class name in `app.css`
6. Build and verify

---

## Renaming a Collection

1. Update all product entries in `CatalogStore.cs` — change the `Collection` value
2. Update the house card in `About.razor` if it exists
3. Build and verify
