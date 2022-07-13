using Domain.Entities;

namespace Domain.Interfaces;
public interface IProductService
{
    Task<Product> GetAsync(int id);
    Task<IReadOnlyList<Product>> GetAllProductAsync();

    Task UpdateAsync(Product product);
    Task CreateAsync(Product product);
    Task DeleteAsync(int id);
 
}
