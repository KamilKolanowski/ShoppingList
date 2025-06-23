using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Data;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public class ShoppingListRepository : IShoppingListRepository
{
    private readonly ShoppingListDbContext _context;
    public ShoppingListRepository(ShoppingListDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ShoppingList>> GetAllShoppingLists()
    {
        return await _context.ShoppingList.ToListAsync();
    }

    public async Task<ShoppingList?> GetShoppingList(int shoppingListId)
    {
        return await _context.ShoppingList.FindAsync(shoppingListId);
    }

    public async Task<bool> AddShoppingList(ShoppingList shoppingList)
    {
        try
        {
            await _context.ShoppingList.AddAsync(shoppingList);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> UpdateShoppingList(ShoppingList shoppingList)
    {
        try
        {
            _context.ShoppingList.Update(shoppingList);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteShoppingList(int shoppingListId)
    {
        try
        {
            var shoppingList = await _context.ShoppingList.FindAsync(shoppingListId);
            _context.ShoppingList.Remove(shoppingList);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}