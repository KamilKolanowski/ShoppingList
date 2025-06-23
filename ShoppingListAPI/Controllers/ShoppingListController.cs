using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Controllers;

[ApiController]
[Route("api/shopping-list")]
public class ShoppingListController : ControllerBase
{
    [HttpGet("products")]
    public async Task<IEnumerable<ShoppingList>> GetShoppingList()
    {
        return null;
    }
}