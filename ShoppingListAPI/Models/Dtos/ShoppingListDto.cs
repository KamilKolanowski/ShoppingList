namespace ShoppingListAPI.Models.Dtos;

public class ShoppingListDto
{
    public int? Id { get; set; }
    public string ShoppingListName { get; set; } = string.Empty;
    public List<ShoppingListItemDto> Items { get; set; } = new();
}