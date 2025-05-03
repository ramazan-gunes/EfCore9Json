using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using EfCore9Json.Example;
using EfCore9Json.Example.Models;

using var context = new AppDbContext();
context.Database.EnsureCreated();

// 1. Insert Multiple Products
var insertProducts = new List<Product>
{
    new Product
    {
        Name = "White T-Shirt",
        Category = "Clothing",
        Price = 19.99m,
        Details = new ProductDetails
        {
            Color = "White",
            Size = "M",
            Tags = new[] { "summer", "cotton", "basic" }
        }
    },
    new()
    {
        Name = "Gaming Laptop",
        Category = "Electronics",
        Price = 2499.99m,
        Details = new ProductDetails
        {
            Color = "Black",
            Size = "15-inch",
            Tags = new[] { "gaming", "laptop", "high-end" },
            Specs = new LaptopSpecs
            {
                CPU = "Intel i9",
                RAM = "32GB",
                Storage = "1TB SSD"
            }
        }
    },
    new()
    {
        Name = "4K Monitor",
        Category = "Electronics",
        Price = 599.99m,
        Details = new ProductDetails
        {
            Color = "Black",
            Size = "27-inch",
            Tags = new[] { "monitor", "4k", "display" }
        }
    }
};

context.Products.AddRange(insertProducts);
context.SaveChanges();

Console.WriteLine("Insert completed (SaveChanges). Check logs for SQL.");

// 2. Query White Products
var queryWhite = context.Products
    .Where(p => p.Details.Color == "White");

Console.WriteLine("\n-- SQL: Products where Details.Color = 'White' --");
Console.WriteLine(queryWhite.ToQueryString());

var whiteProducts = queryWhite.ToList();

// 3. Query Intel i9 Laptop
var queryI9 = context.Products
    .Where(p => p.Details.Specs.CPU == "Intel i9");

Console.WriteLine("\n-- SQL: Products where Details.Specs.CPU = 'Intel i9' --");
Console.WriteLine(queryI9.ToQueryString());

var i9Laptop = queryI9.FirstOrDefault();

// 4. Query Products with 'monitor' tag
var queryMonitor = context.Products
    .Where(p => p.Details.Tags.Contains("monitor"));

Console.WriteLine("\n-- SQL: Products where Details.Tags contains 'monitor' --");
Console.WriteLine(queryMonitor.ToQueryString());

var monitorProducts = queryMonitor.ToList();

// 5. Update: Change Monitor Size
var monitor = context.Products.FirstOrDefault(p => p.Name == "4K Monitor");
if (monitor is not null)
{
    monitor.Details.Size = "32-inch";
    context.SaveChanges();
    Console.WriteLine("\nUpdate completed: Changed monitor size to 32-inch.");
    Console.WriteLine("ℹ SQL logged via EF's logging system.");
}
