using Domain.Entities.OrderAggregate;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class OrderService: IOrderService
{
    private readonly StoreContext _storeContext;

    public OrderService(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }

    public Task CreateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Order>> GetAllOrderAsync(int userid)
    {
        return await _storeContext.Orders.Include(c=>c.OrderItems).Where(u=>u.BuyerId == userid.ToString()).ToListAsync();
    }

    public Task<Order> GetAsync(int id, int userid)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }
}
