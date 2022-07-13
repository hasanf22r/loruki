using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class ProductService: IProductService
{
    private readonly StoreContext _storeContext;

    public ProductService(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }

    public async Task CreateAsync(Product product)
    {
        await _storeContext.Products.AddAsync(product);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Product>> GetAllProductAsync()
    {
        return await _storeContext.Products.ToListAsync();
    }

    public Task<Product> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    
}
