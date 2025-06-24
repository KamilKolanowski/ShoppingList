using System.ComponentModel.DataAnnotations;

namespace ShoppingListAPI.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Required]
    public string ProductName { get; set; } = String.Empty;
    public decimal Price { get; set; }
}
