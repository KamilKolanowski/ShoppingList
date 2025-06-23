using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public interface IShoppingListRepository
{
    Task<IEnumerable<ShoppingList>> GetAllShoppingLists();
    Task<ShoppingList?> GetShoppingList(int shoppingListId);
    Task<bool> AddShoppingList(ShoppingList shoppingList);
    Task<bool> UpdateShoppingList(ShoppingList shoppingList);
    Task<bool> DeleteShoppingList(int shoppingListId);
    
}