
# EF Core 9 – Advanced JSON Column Mapping with PostgreSQL

This project demonstrates how to use **EF Core 9's enhanced JSON column support** in a realistic e-commerce scenario using PostgreSQL. It includes:

- Hybrid relational + JSON modeling
- Nested owned entities serialized to JSONB
- LINQ queries over JSON fields
- JSON indexing strategies and performance comparison

> ⚠️ This project uses `.NET 9 Preview` and `EF Core 9 Preview`.

---

## 📦 Technologies

- [.NET 9 SDK (Preview)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [EF Core 9 Preview](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-9.0/whatsnew)
- [Npgsql PostgreSQL Provider](https://www.npgsql.org/efcore/)

---

## 🚀 Getting Started

The app will:

- Create a database schema (if needed)
- Seed up to 100,000 product records with dynamic JSON content
- Run sample LINQ queries on JSON fields
- Print SQL queries to the console via `ToQueryString()`
- Show performance difference between indexed vs non-indexed scenarios

---

## 🛠 JSON Model Example

Each `Product` contains a strongly typed `ProductDetails` property mapped to a single `jsonb` column.

```csharp
public class ProductDetails
{
    public string Color { get; set; }
    public string Size { get; set; }
    public string[] Tags { get; set; }
    public LaptopSpecs Specs { get; set; }
}
```

This structure is serialized to JSON in PostgreSQL.

---

## 📈 Performance & Indexing

You can add or drop indexes like:

```sql
CREATE INDEX idx_details_color
ON "Products" ((Details ->> 'Color'));

DROP INDEX IF EXISTS idx_details_color;
```

Use `EXPLAIN ANALYZE` to measure impact:
```sql
EXPLAIN ANALYZE
SELECT * FROM "Products"
WHERE "Details" ->> 'Color' = 'Red';
```

---

## 📚 Resources

- [EF Core 9 JSON Mapping Docs](https://learn.microsoft.com/en-us/ef/core/modeling/json-columns)
- [PostgreSQL JSON Functions](https://www.postgresql.org/docs/current/functions-json.html)
- [PostgreSQL Index Types](https://www.postgresql.org/docs/current/indexes-types.html)

---

## 🧑‍💻 Author

Created by [Ramazan Güneş](https://medium.com/@gunesramazan)  
📍 Istanbul, Türkiye  
📫 [LinkedIn](https://linkedin.com/in/ramazangns) – [GitHub](https://github.com/ramazan-gunes)