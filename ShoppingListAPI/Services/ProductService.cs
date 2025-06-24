using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services;

public class ProductService : IEntityService<Product>
{
    public Task<IEnumerable<ShoppingList>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingList?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task PostAsync(Product item)
    {
        throw new NotImplementedException();
    }

    public Task PutAsync(Product item)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}