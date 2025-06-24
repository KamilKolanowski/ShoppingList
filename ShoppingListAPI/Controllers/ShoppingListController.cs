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
            var dtos = entities.Select(MapToDto);
            return Ok(dtos);
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
            return Ok(MapToDto(entity));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostShoppingList(ShoppingListDto shoppingListDto)
    {
        try
        {
            var entity = MapToEntity(shoppingListDto);
            await _shoppingListService.PostAsync(entity);
            var dto = MapToDto(entity);
            return CreatedAtAction(nameof(GetShoppingList), new { id = dto.Id }, dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutShoppingList(int id, ShoppingListDto shoppingListDto)
    {
        try
        {
            if (id != shoppingListDto.Id)
                return BadRequest("Id mismatch");

            var entity = MapToEntity(shoppingListDto);
            await _shoppingListService.PutAsync(entity);
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

    // Mapping methods:

    private ShoppingListDto MapToDto(ShoppingList entity)
    {
        return new ShoppingListDto
        {
            Id = entity.Id,
            ShoppingListName = entity.ShoppingListName,
            Items = entity
                .Items.Select(i => new ShoppingListItemDto
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Weight = i.Weight,
                    Total = i.Total,
                    IsPickedUp = i.IsPickedUp,
                })
                .ToList(),
        };
    }

    private ShoppingList MapToEntity(ShoppingListDto dto)
    {
        return new ShoppingList
        {
            Id = dto.Id ?? 0,
            ShoppingListName = dto.ShoppingListName,
            Items = dto
                .Items.Select(i => new ShoppingListItem
                {
                    Id = i.Id ?? 0,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Weight = i.Weight,
                    Total = i.Total,
                    IsPickedUp = i.IsPickedUp,
                })
                .ToList(),
        };
    }
}
