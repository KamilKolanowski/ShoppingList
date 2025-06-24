using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Services;

public class ShoppingListItemService : IEntityService<ShoppingListItem>
{
    private readonly IDataRepository<ShoppingListItem> _repository;

    public ShoppingListItemService(IDataRepository<ShoppingListItem> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ShoppingListItem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ShoppingListItem?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task PostAsync(ShoppingListItem item)
    {
        await _repository.AddAsync(item);
    }

    public async Task PutAsync(ShoppingListItem item)
    {
        await _repository.UpdateAsync(item);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
