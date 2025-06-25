using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services;

public class ProductService : IEntityService<Product>
{
    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> PostAsync(Product item)
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
