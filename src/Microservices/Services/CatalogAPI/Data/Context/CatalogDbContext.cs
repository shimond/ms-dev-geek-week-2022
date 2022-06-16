using CatalogAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Data.Context;

public class CatalogDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }
}
