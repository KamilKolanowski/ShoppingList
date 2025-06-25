using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers;

[ApiController]
[Route("api/shopping-list/items")]
public class ShoppingListItemController : ControllerBase
{
    private readonly IEntityService<ShoppingListItem> _shoppingListItemService;

    public ShoppingListItemController(IEntityService<ShoppingListItem> shoppingListItemService)
    {
        _shoppingListItemService = shoppingListItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllShoppingListItems()
    {
        try
        {
            var entities = await _shoppingListItemService.GetAllAsync();
            return Ok(entities);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShoppingListItem>> GetShoppingListItem(int id)
    {
        try
        {
            var entity = await _shoppingListItemService.GetByIdAsync(id);
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
    public async Task<IActionResult> PostShoppingListItem(ShoppingListItem shoppingListItem)
    {
        try
        {
            var createdItem = await _shoppingListItemService.PostAsync(shoppingListItem);
            if (createdItem == null || createdItem.Id == 0)
                return StatusCode(500, "Failed to create item or ID not generated.");

            return CreatedAtAction(nameof(GetShoppingListItem), new { id = createdItem.Id }, createdItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutShoppingListItem(
        int id,
        ShoppingListItem shoppingListItem
    )
    {
        try
        {
            await _shoppingListItemService.PutAsync(shoppingListItem);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShoppingListItem(int id)
    {
        try
        {
            await _shoppingListItemService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
