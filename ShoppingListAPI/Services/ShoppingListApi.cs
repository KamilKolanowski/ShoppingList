using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Services;

public class ShoppingListApi : IShoppingListApi
{
    private readonly IShoppingListRepository _repository;

    public ShoppingListApi(IShoppingListRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ShoppingList>> GetAllShoppingLists()
    {
        return await _repository.GetAllShoppingLists();
    }

    public async Task<ShoppingList?> GetShoppingList(int shoppingListId)
    {
        return await _repository.GetShoppingList(shoppingListId);
    }

    public async Task PostShoppingList(ShoppingList shoppingList)
    {
        await _repository.AddShoppingList(shoppingList);
    }

    public async Task PutShoppingList(ShoppingList shoppingList)
    {
        await _repository.UpdateShoppingList(shoppingList);
    }

    public async Task DeleteShoppingList(int shoppingListId)
    {
        await _repository.DeleteShoppingList(shoppingListId);
    }
}
