using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers;

[ApiController]
[Route("api/shopping-list/products")]
public class ProductController : ControllerBase
{
    private readonly IEntityService<Product> _productService;

    public ProductController(IEntityService<Product> productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        try
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        try
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostProduct(Product product)
    {
        try
        {
            await _productService.PostAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        try
        {
            if (id != product.Id)
                return BadRequest("Id mismatch");
            await _productService.PutAsync(product);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
