using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services;

public interface IShoppingListApi
{
    Task<IEnumerable<ShoppingList>> GetAllShoppingLists();
    Task<ShoppingList?> GetShoppingList(int shoppingListId);
    Task PostShoppingList(ShoppingList shoppingList);
    Task PutShoppingList(ShoppingList shoppingList);
    Task DeleteShoppingList(int shoppingListId);
}
