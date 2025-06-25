using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services;

public interface IEntityService<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> PostAsync(T item);
    Task<T?> PutAsync(T item);
    Task DeleteAsync(int id);
}
