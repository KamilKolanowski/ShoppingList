using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Data;

public class ShoppingListDbContext : DbContext
{
    public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ShoppingList> ShoppingList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TCSA");
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ShoppingListName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar(100)");
            entity.Property(e => e.ProductName).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
            entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(e => e.Quantity).IsRequired().HasColumnType("int");
            entity.Property(e => e.Weight).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Total).IsRequired().HasColumnType("decimal(18,2)");
        });
    }

}