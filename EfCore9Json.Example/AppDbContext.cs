using EfCore9Json.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore9Json.Example;

public class AppDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=RG_Pass_1;Database=efcore9db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().OwnsOne(p => p.Details, nav =>
        {
            nav.ToJson();

            nav.OwnsOne(d => d.Specs); // Nested object inside the JSON
        });
    }
}