using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Data;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public class ShoppingListItemRepository : IDataRepository<ShoppingListItem>
{
    private readonly ShoppingListDbContext _context;

    public ShoppingListItemRepository(ShoppingListDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ShoppingListItem>> GetAllAsync()
    {
        return await _context.ShoppingListItems.ToListAsync();
    }

    public async Task<ShoppingListItem?> GetByIdAsync(int id)
    {
        return await _context.ShoppingListItems.FindAsync(id);
    }

    public async Task<ShoppingListItem?> AddAsync(ShoppingListItem item)
    {
        try
        {
            await _context.ShoppingListItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }

    public async Task<ShoppingListItem?> UpdateAsync(ShoppingListItem item)
    {
        try
        {
            _context.ShoppingListItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }

    public async Task<ShoppingListItem?> DeleteAsync(int id)
    {
        try
        {
            var shoppingListItem = await _context.ShoppingListItems.FindAsync(id);
            _context.ShoppingListItems.Remove(shoppingListItem);
            await _context.SaveChangesAsync();
            return shoppingListItem;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }
}
