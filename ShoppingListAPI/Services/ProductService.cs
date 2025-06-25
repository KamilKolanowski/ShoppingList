using ShoppingListAPI.Models;
using ShoppingListAPI.Repositories;

namespace ShoppingListAPI.Services;

public class ProductService : IEntityService<Product>
{
    private readonly IDataRepository<Product> _repository;

    public ProductService(IDataRepository<Product> repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Product?> PostAsync(Product item)
    {
        var createdProduct = await _repository.AddAsync(item);
        return createdProduct;
    }

    public async Task<Product?> PutAsync(Product item)
    {
        var updatedProduct = await _repository.UpdateAsync(item);
        return updatedProduct;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
