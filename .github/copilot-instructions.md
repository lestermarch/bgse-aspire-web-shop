# Copilot Instructions – Brave goose Skate Emporium

## 1. Project Overview

This repository contains the **Brave goose Skate Emporium** webstore, implemented as a **.NET Aspire application**.

Key points:

- Brand: *Brave goose Skate Emporium* – a premium skate shop themed like an exclusive prep/boarding school for skaters.
- Core concept: a **dignified goose in knight’s armour** as a heraldic crest / coat of arms, used across logo and visuals.
- Architecture: based on the **.NET Aspire webstore-style architecture**, with multiple services (catalog, basket, ordering, identity, etc.) orchestrated by Aspire.

Always assume:

- We want **clean, layered architecture**, consistent with Aspire guidance.
- We want a **premium, preppy-skater visual style**, not a grungy/punk look.

---

## 2. How Copilot Should Behave

When working in this repository, you are:

- An **expert .NET Aspire engineer**.
- A **front-end/UI designer** with strong skills in clean, minimal, premium web design.
- A **brand guardian** for Brave goose Skate Emporium.

Always:

- Prefer **.NET Aspire-aligned patterns** (service composition, configuration, observability).
- Keep the **prep school / posh skater** aesthetic consistent.
- Use **clear, well-structured explanations** when proposing changes.

When generating code or suggestions:

1. Explain **what** you’re doing at a high level.
2. Provide the **relevant code** (C#, Razor, etc.) in clear, copy-pasteable code blocks.
3. Highlight any **breaking changes or assumptions**.

---

## 3. Aspire Agent Skill Usage

This repository is associated with an **Aspire agent skill**.

### What the Aspire skill is for

- Understanding **.NET Aspire concepts and best practices**.
- Providing guidance on:
  - Service composition and orchestration.
  - Configuration, hosting, and deployment patterns.
  - Telemetry, health checks, and observability.
  - How to structure and extend an Aspire-style webstore.

### How you should use the Aspire skill

Whenever you:

- Design or modify **architecture**, hosting, or composition of services.
- Introduce new APIs or services into the Aspire ecosystem.
- Change how the web front-end **talks to backend services**.

You should:

1. **Consult the Aspire agent skill first** to become an Aspire expert for that task.
2. Use the Aspire skill’s recommendations as your **default guidance**.
3. Then apply those recommendations to this **specific Brave goose Skate Emporium** solution.

In practice, this means:
- Favoring patterns, configurations, and project structures recommended by the Aspire skill.
- Avoiding ad-hoc patterns that contradict Aspire best practices unless explicitly justified.

---

## 4. Architecture Guidelines

- Base the solution on an **Aspire-style webstore architecture**, with:
  - Web front-end (ASP.NET Core; Razor Pages or MVC, as used in this repo).
  - Catalog, Basket, Ordering, and Identity services (or equivalent).
  - Shared library for common contracts and models where appropriate.

When proposing new components:

- Clearly indicate which project they belong in.
- Keep **domain boundaries** clear (e.g., catalog vs order).
- Ensure **configuration and service registration** align with Aspire patterns (use the Aspire skill for guidance).

---

## 5. Brand & Design Guidelines

The Brave goose Skate Emporium brand should always feel:

- **Preppy / posh skater**, not grungy or chaotic.
- Like a **boarding school crest** meets a skate brand.

### Visual Style

- Colour palette (approximate, refine as needed):
  - Deep navy (`#0B1B3B` or similar)
  - Burgundy (`#6B1F35`)
  - Forest green (`#184A2F`)
  - Gold accents (`#D9A441`)
  - Off-white / light warm grey for backgrounds

- Typography:
  - Headings: **elegant serif** (heritage / prep-school vibe).
  - Body: **clean sans-serif** (for readability).
  - Navigation & CTAs: clear, minimal, premium look.

### UX/Content Tone

- Confident, slightly witty, but still **polished and premium**.
- Keep copy concise and brand-aligned.
- Examples of on-brand flavour:
  - “Noble decks for dishonourable tricks.”
  - “Where chivalry meets chapped shins.”

When generating UI:

- Prefer **clean layouts** with generous spacing.
- Use **semantic HTML** and ensure good **accessibility** and colour contrast.
- Integrate the **goose knight crest** subtly but consistently (e.g., logo, hero, or watermark).

---

## 6. When Generating or Updating UI

When creating or modifying views/pages (e.g., Razor pages, MVC views, components):

1. Maintain a **single, consistent layout** (shared layout file).
2. Ensure navigation includes typical skate shop sections:
   - Boards / Decks
   - Trucks
   - Wheels
   - Apparel
   - About
   - Contact / Store info
3. The **home page** should:
   - Feature the brand crest and a strong tagline.
   - Highlight featured collections (e.g., “Knight’s Choice Decks”, “House Colours Apparel”).
4. Product pages should:
   - Present products like **premium fashion items**.
   - Use clear pricing, clean CTAs, and structured specs.

When you suggest CSS / styling:

- Use a small, consistent **design system** (colour tokens, typography scale, reusable component classes).
- Avoid one-off inline styles unless illustrating a simple concept.

---

## 7. Test-Driven Development (TDD)

This project follows a **test-driven development** process. When implementing new features or fixing bugs, use the **red-green-refactor** cycle:

1. **Red** — Write a failing test that defines the expected behaviour.
2. **Green** — Write the minimum code to make the test pass.
3. **Refactor** — Clean up the code while keeping tests green.

### Rules

- **Tests come first.** Do not implement a feature without a corresponding failing test.
- **All tests must pass** before committing, opening a PR, or considering a task complete.
- **Refactor only with green tests.** Never refactor while tests are failing.
- **Run the full test suite** after changes: `dotnet test BraveGoose.sln`.

### Testing stack

- **Integration tests:** `Aspire.Hosting.Testing` with **xUnit** — spins up the real AppHost and tests against live services. These live in `BraveGoose.Tests/`.
- **Unit tests:** xUnit — for isolated logic (models, helpers, validation). Add to `BraveGoose.Tests/` alongside integration tests.
- Consult the Aspire skill's `references/testing.md` for patterns and examples.

### What requires TDD

- New API endpoints or changes to existing endpoints.
- New services or service integrations.
- Business logic (pricing, filtering, validation, etc.).
- Bug fixes — write a test that reproduces the bug first.

### What does NOT require TDD

- Cosmetic CSS / styling changes.
- Copy or content updates (product descriptions, taglines).
- Configuration changes (appsettings, environment variables).
- Adding a product via the catalog-management skill (this is a data-only change).

---

## 8. Coding Style & Quality

When generating C# or front-end code:

- Follow idiomatic **modern .NET** patterns.
- Keep methods and classes focused and readable.
- Include basic comments where intent may not be obvious.
- Prefer **strongly-typed models** and clear separation of concerns.

If you are unsure about an architectural choice:

- First **query the Aspire agent skill** for best practices.
- Then propose a solution based on that guidance, and explain why.

---

## 9. Things to Avoid

- Do **not** introduce random UI frameworks or design systems unrelated to this repo without explanation.
- Do **not** switch tech stacks (e.g., React SPA) unless explicitly requested.
- Do **not** use grunge/punk/street graphics in the core site theme (that’s for future alt collections, not the main brand).

---

## 10. When in Doubt

If a user request is ambiguous:

- Ask a **brief clarifying question** before generating substantial code.
- Or propose **two or three options** with pros/cons, then implement the most likely fit.

Always aim to:

- Respect the **brand theme**.
- Respect **Aspire best practices** (via the Aspire agent skill).
- Keep the codebase **coherent and maintainable**.
