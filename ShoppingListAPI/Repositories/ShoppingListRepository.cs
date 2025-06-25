using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Data;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public class ShoppingListRepository : IDataRepository<ShoppingList>
{
    private readonly ShoppingListDbContext _context;

    public ShoppingListRepository(ShoppingListDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ShoppingList>> GetAllAsync()
    {
        return await _context.ShoppingLists.ToListAsync();
    }

    public async Task<ShoppingList?> GetByIdAsync(int id)
    {
        return await _context.ShoppingLists.FindAsync(id);
    }

    public async Task<ShoppingList?> AddAsync(ShoppingList shoppingList)
    {
        try
        {
            await _context.ShoppingLists.AddAsync(shoppingList);
            await _context.SaveChangesAsync();
            return shoppingList;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }

    public async Task<ShoppingList?> UpdateAsync(ShoppingList shoppingList)
    {
        try
        {
            _context.ShoppingLists.Update(shoppingList);
            await _context.SaveChangesAsync();
            return shoppingList;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }

    public async Task<ShoppingList?> DeleteAsync(int id)
    {
        try
        {
            var shoppingList = await _context.ShoppingLists.FindAsync(id);
            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();
            return shoppingList;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("DB update failed: " + ex.InnerException?.Message, ex);
        }
    }
}
