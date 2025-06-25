using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public interface IDataRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> AddAsync(T item);
    Task<T?> UpdateAsync(T item);
    Task<T?> DeleteAsync(int id);
}
