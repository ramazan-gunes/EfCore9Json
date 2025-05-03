using Microsoft.EntityFrameworkCore;

namespace EfCore9Json.Example.Models;

[Owned]
public class LaptopSpecs
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
}