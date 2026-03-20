# GitHub Workflow — Issue-to-PR Product Pipeline

How the Brave Goose Skate Emporium uses GitHub Issues as a product management interface.

---

## Overview

```
Human fills issue form → Copilot assigned → Agent makes changes → PR opened → Human reviews → Merge
```

Non-technical stakeholders can add products without touching code, git, or the IDE. GitHub is the CMS.

---

## Issue Template

**Location:** `.github/ISSUE_TEMPLATE/new-product.yml`

The form collects:

| Field | Type | Required | Notes |
|---|---|---|---|
| Product name | Text input | ✅ | Display name |
| Category | Dropdown | ✅ | Boards, Trucks, Wheels, Apparel |
| Collection | Dropdown | ✅ | Knight's Choice, House Colours, The Quad, Crest Collection |
| Price (GBP) | Text input | ✅ | Numeric, no £ symbol |
| Description | Textarea | ✅ | Rough description — agent rewrites in brand voice |
| Featured | Dropdown | ✅ | Yes / No |
| Image | Textarea (drag-drop) | ❌ | Optional image attachment |
| Notes | Textarea | ❌ | Additional context |

Issues created from this template are auto-labelled `new-product`.

---

## Agent Instructions

**Location:** `.github/copilot-instructions-new-product.md`

When Copilot is assigned to a `new-product` issue, it follows a defined procedure:

1. Parse the form fields
2. Determine the next product ID
3. Rewrite the description in brand voice
4. Generate the image slug
5. Process and place the image (if provided)
6. Add the product to `CatalogStore.cs`
7. Build and verify
8. Open a PR linked to the issue

### Guardrails

The agent is explicitly constrained:

- **Only modifies** `CatalogStore.cs` and the image directory
- **Never changes** existing products, the data model, API, or frontend
- **Never invents** a price — uses the exact value from the form
- **Never guesses** on missing fields — asks for clarification instead
- **Always requests review** from the issue author and repo owners

---

## Review Workflow

### CODEOWNERS

**Location:** `.github/CODEOWNERS`

Changes to catalog data and product images automatically request review from `@lestermarch`.

### PR expectations

The PR body should include:
- The original description from the issue (for comparison)
- The rewritten brand-voice description
- A note explaining any changes
- `Closes #<issue-number>` to auto-close the issue on merge

### Reviewer checklist

- [ ] Product name is correct and unique
- [ ] Price is accurate (matches issue form exactly)
- [ ] Category and collection are correct
- [ ] Brand-voice description is on-tone and specs are preserved
- [ ] Image looks good (if provided) — correct dimensions, clean background
- [ ] Build passes

---

## Future Extensions

These templates could be added later to expand the workflow:

| Template | Purpose |
|---|---|
| **Update Product** | Change price, description, featured status, or image for an existing product |
| **Remove Product** | Retire a product from the catalog |
| **New Category** | Add a new product category (multi-file change) |
| **New Collection** | Add a new collection / house |
