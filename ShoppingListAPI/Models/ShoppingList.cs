using System.ComponentModel.DataAnnotations;

namespace ShoppingListAPI.Models;

public class ShoppingList
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    [Required]
    public string ShoppingListName { get; set; } = String.Empty;
    [StringLength(200)]
    [Required]
    public string ProductName { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal? Weight { get; set; }
    public decimal Total { get; set; }
}