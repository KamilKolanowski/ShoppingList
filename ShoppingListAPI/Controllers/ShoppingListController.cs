using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Models.Dtos;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers;

[ApiController]
[Route("api/shopping-list")]
public class ShoppingListController : ControllerBase
{
    private readonly IEntityService<ShoppingList> _shoppingListService;

    public ShoppingListController(IEntityService<ShoppingList> shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }

    [HttpGet]
    public async Task<IActionResult> GetShoppingList()
    {
        try
        {
            var entities = await _shoppingListService.GetAllAsync();
            return Ok(entities);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShoppingList(int id)
    {
        try
        {
            var entity = await _shoppingListService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostShoppingList(ShoppingList shoppingList)
    {
        try
        {
            await _shoppingListService.PostAsync(shoppingList);
            return CreatedAtAction(nameof(GetShoppingList), new { id = shoppingList.Id }, shoppingList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutShoppingList(int id, ShoppingList shoppingList)
    {
        try
        {
            if (id != shoppingList.Id)
                return BadRequest("Id mismatch");
            await _shoppingListService.PutAsync(shoppingList);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShoppingList(int id)
    {
        try
        {
            await _shoppingListService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
