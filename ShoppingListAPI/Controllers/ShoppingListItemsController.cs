using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Models.Dtos;
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
            var dtos = new List<ShoppingListItemDto>();
            foreach (var entity in entities)
            {
                dtos.Add(MapToDto(entity));
            }
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShoppingListItem(int id)
    {
        try
        {
            var entity = await _shoppingListItemService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            return Ok(MapToDto(entity));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostShoppingListItem(ShoppingListItemDto shoppingListItemDto)
    {
        try
        {
            var entity = MapToEntity(shoppingListItemDto);
            await _shoppingListItemService.PostAsync(entity);
            return CreatedAtAction(nameof(GetShoppingListItem), new { id = entity.Id }, MapToDto(entity));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutShoppingListItem(
        int id,
        ShoppingListItemDto shoppingListItemDto
    )
    {
        try
        {
            var entity = MapToEntity(shoppingListItemDto);
            await _shoppingListItemService.PutAsync(entity);
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

    private ShoppingListItemDto MapToDto(ShoppingListItem entity)
    {
        return new ShoppingListItemDto
        {
            Id = entity.Id,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity,
            Weight = entity.Weight,
            Total = entity.Total,
            IsPickedUp = entity.IsPickedUp,
        };
    }

    private ShoppingListItem MapToEntity(ShoppingListItemDto dto)
    {
        return new ShoppingListItem
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            Weight = dto.Weight,
            Total = dto.Total,
            IsPickedUp = dto.IsPickedUp,
        };
    }
}
