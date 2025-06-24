using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services;

public class ShoppingListItemService : IEntityService<ShoppingListItem>
{
    public Task<IEnumerable<ShoppingList>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingList?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task PostAsync(ShoppingListItem item)
    {
        throw new NotImplementedException();
    }

    public Task PutAsync(ShoppingListItem item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}