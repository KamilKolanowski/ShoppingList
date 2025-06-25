using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Data;

public class ShoppingListDbContext : DbContext
{
    public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
        : base(options) { }

    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingListItem> ShoppingListItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TCSA");
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity
                .Property(e => e.ShoppingListName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            entity
                .HasMany(e => e.Items)
                .WithOne(i => i.ShoppingList)
                .HasForeignKey(i => i.ShoppingListId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity
                .Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<ShoppingListItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity
                .HasOne(i => i.ShoppingList)
                .WithMany(s => s.Items)
                .HasForeignKey(i => i.ShoppingListId);

            entity.HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId);

            entity.Property(i => i.Quantity).IsRequired().HasColumnType("int");
            entity.Property(i => i.Weight).HasColumnType("decimal(18,2)");
            entity.Property(i => i.Total).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(i => i.IsPickedUp).IsRequired().HasColumnType("bit");
        });
    }

}
