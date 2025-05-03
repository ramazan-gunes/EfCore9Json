using Microsoft.EntityFrameworkCore;

namespace EfCore9Json.Example.Models;

[Owned]
public class ProductDetails
{
    public string Color { get; set; }
    public string Size { get; set; }

    public LaptopSpecs Specs { get; set; } // Nested owned type
    public string[] Tags { get; set; }
}