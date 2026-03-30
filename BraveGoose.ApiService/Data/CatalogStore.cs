using BraveGoose.ApiService.Models;

namespace BraveGoose.ApiService.Data;

public static class CatalogStore
{
    public static List<Product> GetProducts() =>
    [
        // Boards
        new Product
        {
            Id = 1,
            Name = "The Lancelot",
            Description = "A noble 8.0\" deck forged for those who joust with handrails. Maple construction, unyielding resolve.",
            Price = 149.99m,
            Category = "Boards",
            Collection = "Knight's Choice",
            ImageUrl = "/images/products/the-lancelot.jpg",
            IsFeatured = true
        },
        new Product
        {
            Id = 2,
            Name = "Vanguard Cruiser",
            Description = "Lead the charge through campus on this smooth-riding cruiser. Effortless glide, distinguished profile.",
            Price = 129.99m,
            Category = "Boards",
            Collection = "Crest Collection",
            ImageUrl = "/images/products/vanguard-cruiser.jpg",
            IsFeatured = true
        },
        new Product
        {
            Id = 3,
            Name = "Shield Wall 8.25\"",
            Description = "Wide, stable, and built for the front lines of every skatepark. Your defence against mediocre decks.",
            Price = 139.99m,
            Category = "Boards",
            Collection = "The Quad",
            ImageUrl = "/images/products/shield-wall-825.jpg",
            IsFeatured = false
        },
        new Product
        {
            Id = 4,
            Name = "The Pennant",
            Description = "Fly your colours with this lightweight street deck. Quick, responsive, and unmistakably gallant.",
            Price = 119.99m,
            Category = "Boards",
            Collection = "House Colours",
            ImageUrl = "/images/products/the-pennant.jpg",
            IsFeatured = false
        },

        // Trucks
        new Product
        {
            Id = 5,
            Name = "Iron Gauntlet 149mm",
            Description = "Precision-forged trucks that grip the road like a knight grips a lance. Sturdy, reliable, honourable.",
            Price = 64.99m,
            Category = "Trucks",
            Collection = "Knight's Choice",
            ImageUrl = "/images/products/iron-gauntlet-149mm.jpg",
            IsFeatured = true
        },
        new Product
        {
            Id = 6,
            Name = "Squire Standard 139mm",
            Description = "Every knight starts as a squire. Solid entry-level trucks for those beginning their noble journey.",
            Price = 54.99m,
            Category = "Trucks",
            Collection = "The Quad",
            ImageUrl = "/images/products/squire-standard-139mm.jpg",
            IsFeatured = false
        },
        new Product
        {
            Id = 7,
            Name = "Noble Hollow 149mm",
            Description = "Hollowed-out kingpin and axle for a lighter ride. Because true nobility never weighs you down.",
            Price = 74.99m,
            Category = "Trucks",
            Collection = "Crest Collection",
            ImageUrl = "/images/products/noble-hollow-149mm.jpg",
            IsFeatured = false
        },
        new Product
        {
            Id = 8,
            Name = "The Herald Low",
            Description = "Low-profile trucks that announce your arrival at every spot. Stability meets swagger.",
            Price = 59.99m,
            Category = "Trucks",
            Collection = "House Colours",
            ImageUrl = "/images/products/the-herald-low.jpg",
            IsFeatured = false
        },

        // Wheels
        new Product
        {
            Id = 9,
            Name = "Courtyard 54mm 99a",
            Description = "All-purpose wheels for sessioning the courtyard between lectures. Smooth on concrete, poised on marble.",
            Price = 42.99m,
            Category = "Wheels",
            Collection = "The Quad",
            ImageUrl = "/images/products/courtyard-54mm.jpg",
            IsFeatured = false
        },
        new Product
        {
            Id = 10,
            Name = "The Rampart 56mm 101a",
            Description = "Hard, fast, and built for park conquest. These wheels hold their line like castle walls.",
            Price = 46.99m,
            Category = "Wheels",
            Collection = "Knight's Choice",
            ImageUrl = "/images/products/the-rampart-56mm.jpg",
            IsFeatured = true
        },
        new Product
        {
            Id = 11,
            Name = "Pennant Soft 58mm 78a",
            Description = "Buttery-smooth cruiser wheels for the scholar who prefers the scenic route. Comfortable and composed.",
            Price = 39.99m,
            Category = "Wheels",
            Collection = "House Colours",
            ImageUrl = "/images/products/pennant-soft-58mm.jpg",
            IsFeatured = false
        },
        new Product
        {
            Id = 12,
            Name = "Crest 52mm 100a",
            Description = "Compact street wheels bearing the house crest. Technical skating deserves a distinguished wheel.",
            Price = 44.99m,
            Category = "Wheels",
            Collection = "Crest Collection",
            ImageUrl = "/images/products/crest-52mm.jpg",
            IsFeatured = false
        },

        // Apparel
        new Product
        {
            Id = 13,
            Name = "House Crest Tee",
            Description = "Premium cotton tee emblazoned with the Brave Goose crest. Dress code: noble but casual.",
            Price = 38.99m,
            Category = "Apparel",
            Collection = "Crest Collection",
            ImageUrl = "/images/products/house-crest-tee.jpg",
            IsFeatured = true
        },
        new Product
        {
            Id = 14,
            Name = "Brave Goose Hoodie",
            Description = "Heavyweight hoodie fit for a chilly morning session. Embroidered crest, kangaroo pocket, regal warmth.",
            Price = 79.99m,
            Category = "Apparel",
            Collection = "Knight's Choice",
            ImageUrl = "/images/products/brave-goose-hoodie.jpg",
            IsFeatured = true
        },
        new Product
        {
            Id = 15,
            Name = "Knight's Cap",
            Description = "Structured snapback with gold-thread crest embroidery. Protect your crown; you've earned it.",
            Price = 32.99m,
            Category = "Apparel",
            Collection = "House Colours",
            ImageUrl = "/images/products/knights-cap.jpg",
            IsFeatured = false
        },
        new Product
        {
            Id = 16,
            Name = "Heraldic Socks Pack",
            Description = "Three pairs of premium knit socks in house colours. Because chivalry starts from the feet up.",
            Price = 18.99m,
            Category = "Apparel",
            Collection = "The Quad",
            ImageUrl = "/images/products/heraldic-socks-pack.jpg",
            IsFeatured = false
        },

        // Bearings — Squire line
        new Product
        {
            Id = 17,
            Name = "Bones Reds",
            Description = "Every squire's first bearing. Reliable steel construction with Speed Cream lubrication — ready for courtyard sessions straight from the box.",
            Price = 20.00m,
            Category = "Bearings",
            Collection = "The Quad",
            ImageUrl = "/images/products/bones-reds.jpg",
            IsFeatured = false
        },

        // Bearings — Knight line
        new Product
        {
            Id = 18,
            Name = "Bones Race Reds",
            Description = "Built-in spacers for precision alignment and effortless installation. A knight's bearing, assembled with purpose.",
            Price = 35.00m,
            Category = "Bearings",
            Collection = "House Colours",
            ImageUrl = "/images/products/bones-race-reds.jpg",
            IsFeatured = false
        },
        new Product
        {
            Id = 19,
            Name = "Bones Super Reds",
            Description = "Higher-grade steel races and a superior surface finish. Quieter, smoother, and longer-lasting — a distinguished upgrade.",
            Price = 35.00m,
            Category = "Bearings",
            Collection = "Crest Collection",
            ImageUrl = "/images/products/bones-super-reds.jpg",
            IsFeatured = false
        },
        new Product
        {
            Id = 20,
            Name = "Bones Big Balls",
            Description = "Six oversized balls deliver greater speed and superior impact resistance. Bold engineering for bold skating.",
            Price = 35.00m,
            Category = "Bearings",
            Collection = "House Colours",
            ImageUrl = "/images/products/bones-big-balls.jpg",
            IsFeatured = false
        },

        // Bearings — Hero line
        new Product
        {
            Id = 21,
            Name = "Bones Swiss",
            Description = "Swiss-made precision. Legendary speed, impeccable tolerances, and a heritage of excellence. The hero's bearing.",
            Price = 60.00m,
            Category = "Bearings",
            Collection = "Crest Collection",
            ImageUrl = "/images/products/bones-swiss.jpg",
            IsFeatured = true
        },
        new Product
        {
            Id = 22,
            Name = "Bones Super Swiss 6",
            Description = "Six oversized Swiss steel balls for faster acceleration and greater durability. Precision-forged for the elite.",
            Price = 60.00m,
            Category = "Bearings",
            Collection = "Knight's Choice",
            ImageUrl = "/images/products/bones-super-swiss-6.jpg",
            IsFeatured = false
        },

        // Bearings — Monarch line
        new Product
        {
            Id = 23,
            Name = "Bones Ceramic",
            Description = "Ceramic balls in Swiss steel races. The sovereign of bearings — unmatched speed, peerless precision, absolute supremacy.",
            Price = 120.00m,
            Category = "Bearings",
            Collection = "Knight's Choice",
            ImageUrl = "/images/products/bones-ceramic.jpg",
            IsFeatured = true
        }
    ];
}
