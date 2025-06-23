using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers;

[ApiController]
[Route("api/shopping-list/")]
public class ShoppingListController : ControllerBase
{
    private readonly IShoppingListApi _shoppingListApi;

    public ShoppingListController(IShoppingListApi shoppingListApi)
    {
        _shoppingListApi = shoppingListApi;
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetShoppingList()
    {
        try
        {
            var shoppingLists = await _shoppingListApi.GetAllShoppingLists();
            return Ok(shoppingLists);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetShoppingList(int id)
    {
        try
        {
            var shoppingList = await _shoppingListApi.GetShoppingList(id);
            return Ok(shoppingList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPost("products")]
    public async Task<IActionResult> PostShoppingList(ShoppingList shoppingList)
    {
        try
        {
            await _shoppingListApi.PostShoppingList(shoppingList);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPut("products")]
    public async Task<IActionResult> PutShoppingList(ShoppingList shoppingList)
    {
        try
        {
            await _shoppingListApi.PutShoppingList(shoppingList);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpDelete("products")]
    public async Task<IActionResult> DeleteShoppingList(int id)
    {
        try
        {
            await _shoppingListApi.DeleteShoppingList(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
