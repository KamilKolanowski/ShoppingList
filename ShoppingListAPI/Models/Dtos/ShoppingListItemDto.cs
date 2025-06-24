namespace ShoppingListAPI.Models.Dtos;

public class ShoppingListItemDto
{
    public int? Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal? Weight { get; set; }
    public decimal Total { get; set; }
    public bool IsPickedUp { get; set; }
}