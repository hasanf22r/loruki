using Domain.Entities.OrderAggregate;

namespace Domain.Interfaces;
public interface IOrderService
{
    Task<Order> GetAsync(int id, int userid);
    Task<IReadOnlyList<Order>> GetAllOrderAsync(int userid);

    Task UpdateAsync(Order order);
    Task CreateAsync(Order order);
    Task DeleteAsync(int id);
}
