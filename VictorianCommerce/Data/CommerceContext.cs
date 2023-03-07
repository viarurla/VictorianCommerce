using Microsoft.EntityFrameworkCore;
using VictorianCommerce.Models;

namespace VictorianCommerce.Data;

public class CommerceContext: DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductPurchase> ProductPurchases { get; set; }

    public CommerceContext(DbContextOptions<CommerceContext> options)
        : base (options)
    {
        
    }
    
    /// <summary>
    /// Initial seeded data for the sake of easy demonstration
    /// would only use this in a production application when we know the data is fixed and have no alternate solutions.
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .Property(pr => pr.Price).HasColumnType("decimal(18,4)");
        
        builder.Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Banana",
                    Price = new decimal(0.35)
                },
                new Product()
                {
                    Id = 2,
                    Name = "Apple",
                    Price = new decimal(1.20)
                },
                new Product()
                {
                    Id = 3,
                    Name = "Pear",
                    Price = new decimal(0.50)
                }
            );
        builder.Entity<Customer>()
            .HasData(
                new Customer
                {
                    Id = 1,
                    Forename = "Oli",
                    Surname = "Norton",
                });
    }
    
}