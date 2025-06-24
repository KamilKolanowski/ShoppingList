using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers;

[ApiController]
[Route("api/shopping-list")]
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
}
