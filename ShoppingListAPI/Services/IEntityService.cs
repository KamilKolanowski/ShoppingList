using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services;

public interface IEntityService<T>
{
    Task<IEnumerable<ShoppingList>> GetAllAsync();
    Task<ShoppingList?> GetByIdAsync(int id);
    Task PostAsync(T item);
    Task PutAsync(T item);
    Task DeleteAsync(int id);
}
