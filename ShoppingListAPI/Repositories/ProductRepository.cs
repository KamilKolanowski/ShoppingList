using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Data;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public class ProductRepository : IDataRepository<Product>
{
    private readonly ShoppingListDbContext _context;

    public ProductRepository(ShoppingListDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product?> AddAsync(Product product)
    {
        try
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }

    public async Task<Product?> UpdateAsync(Product product)
    {
        try
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }

    public async Task<Product?> DeleteAsync(int id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }
}
