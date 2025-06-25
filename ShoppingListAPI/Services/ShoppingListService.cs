using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Services;

public class ShoppingListService : IEntityService<ShoppingList>
{
    private readonly IDataRepository<ShoppingList> _repository;

    public ShoppingListService(IDataRepository<ShoppingList> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ShoppingList>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ShoppingList?> GetByIdAsync(int shoppingListId)
    {
        return await _repository.GetByIdAsync(shoppingListId);
    }

    public async Task<ShoppingList?> PostAsync(ShoppingList shoppingList)
    { 
        var createdList = await _repository.AddAsync(shoppingList);
        return createdList;
    }

    public async Task<ShoppingList?> PutAsync(ShoppingList shoppingList)
    {
        var updatedList = await _repository.UpdateAsync(shoppingList);
        return updatedList;
    }

    public async Task DeleteAsync(int shoppingListId)
    {
        await _repository.DeleteAsync(shoppingListId);
    }
}
