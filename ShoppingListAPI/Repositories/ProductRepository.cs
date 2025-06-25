using ShoppingListAPI.Models;

namespace ShoppingListAPI.Repositories;

public class ProductRepository : IDataRepository<Product>
{
    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> AddAsync(Product item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Product item)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
