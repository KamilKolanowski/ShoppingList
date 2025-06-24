using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListAPI.Models;

public class ShoppingListItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("ShoppingList")]
    public int ShoppingListId { get; set; }
    public ShoppingList? ShoppingList { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal? Weight { get; set; }
    public decimal Total { get; set; }
    public bool IsPickedUp { get; set; }
}
