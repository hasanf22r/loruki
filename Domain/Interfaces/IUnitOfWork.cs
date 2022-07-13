namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IProductService ProductService { get; }
    IOrderService OrderService { get; }
    IBasketService BasketService { get; }
    IUserService UserService { get; }

    Task<int> SaveChangesAsync();
}
