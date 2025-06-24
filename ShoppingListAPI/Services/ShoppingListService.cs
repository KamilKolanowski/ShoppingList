using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Models.Dtos;
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

    public async Task PostAsync(ShoppingList shoppingList)
    { 
        await _repository.AddAsync(shoppingList);
    }

    public async Task PutAsync(ShoppingList shoppingList)
    {
        await _repository.UpdateAsync(shoppingList);
    }

    public async Task DeleteAsync(int shoppingListId)
    {
        await _repository.DeleteAsync(shoppingListId);
    }
}
