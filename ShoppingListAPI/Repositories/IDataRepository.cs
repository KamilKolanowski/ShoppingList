using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public interface IDataRepository<T>
{
    Task<IEnumerable<ShoppingList>> GetAllAsync();
    Task<ShoppingList?> GetByIdAsync(int id);
    Task<bool> AddAsync(T item);
    Task<bool> UpdateAsync(T item);
    Task<bool> DeleteAsync(int id);
}
