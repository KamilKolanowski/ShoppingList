using System.ComponentModel.DataAnnotations;

namespace ShoppingListAPI.Models;

public class ShoppingList
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Required]
    public string ShoppingListName { get; set; } = String.Empty;
    public List<ShoppingListItem> Items { get; set; } = new ();
}
