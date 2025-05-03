namespace EfCore9Json.Example.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }

    // This will be stored as JSON in the database
    public ProductDetails Details { get; set; }
}