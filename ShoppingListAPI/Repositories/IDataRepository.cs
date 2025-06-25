using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public interface IDataRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> AddAsync(T item);
    Task<bool> UpdateAsync(T item);
    Task<bool> DeleteAsync(int id);
}
