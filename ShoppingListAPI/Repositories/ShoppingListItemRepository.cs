using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public class ShoppingListItemRepository : IDataRepository<ShoppingListItem>
{
    public Task<IEnumerable<ShoppingList>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingList?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddAsync(ShoppingListItem item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ShoppingListItem item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}