# Copilot agent instructions for new-product issues
#
# When Copilot is assigned to an issue labelled `new-product`, it should
# follow these instructions to add the product to the catalog.

## Skill

Load the **catalog-management** skill before making any changes. It contains
the full data model, file map, and brand voice guide.

## Procedure

1. **Parse the issue form** — extract: product name, category, collection,
   price, description, featured flag, and image (if attached).

2. **Determine the next product ID** — read `BraveGoose.ApiService/Data/CatalogStore.cs`,
   find the highest existing `Id`, and increment by 1.

3. **Rewrite the description** — using the brand voice reference
   (`references/brand-voice.md`), rewrite the user's rough description into
   1–2 sentences of Brave Goose brand voice. Keep any technical specs
   (dimensions, durometer, material) accurate. Add chivalric / preppy wit.

4. **Generate the image slug** — kebab-case the product name
   (e.g. "The Paladin 8.25\"" → `the-paladin-825`).

5. **Process the image** (if provided):
   - Download the image from the issue attachment URL.
   - Place it at `BraveGoose.Web/wwwroot/images/products/<slug>.jpg`.
   - If the image is larger than 800×800px, resize it proportionally.
   - Create the `images/products/` directory if it doesn't exist.

6. **Add the product entry** — insert a new `Product` block into
   `CatalogStore.cs` in the correct category section, following the
   existing format exactly.

7. **Build and verify** — run `dotnet build BraveGoose.sln` and confirm
   zero errors.

8. **Open a pull request** with:
   - Title: `Add product: <product-name> (<category>)`
   - Body that includes:
     - The original description from the issue
     - The rewritten brand-voice description
     - A note explaining any changes made
   - Link to the originating issue using `Closes #<issue-number>`

## Guardrails

- **Do NOT** modify any files other than `CatalogStore.cs` and the image
  directory. The product model, API endpoints, and frontend are not to be
  changed as part of a new product addition.
- **Do NOT** change existing products — only add the new one.
- **Do NOT** invent a price — always use the exact price from the issue form.
- **Do NOT** change the category or collection — use exactly what the user selected.
- **The featured flag** must match the user's selection (Yes → `true`, No → `false`).
- **If the image is missing**, set `ImageUrl` to the slug path anyway
  (`/images/products/<slug>.jpg`) — the placeholder will display until an
  image is added later.
- **If any required field is missing or ambiguous**, leave a comment on the
  issue asking for clarification rather than guessing.
- **Always request review** from the issue author and repository owners.
