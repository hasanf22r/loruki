using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;
public class UnitOfWork : IUnitOfWork
{
    private readonly StoreContext _storeContext;
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public UnitOfWork(StoreContext storeContext, UserManager<User> userManager, ITokenService tokenService)
    {
        _tokenService = tokenService;
        _storeContext = storeContext;
        _userManager = userManager;
    }


    private IOrderService _orderService;
    public IOrderService OrderService
    {
        get
        {
            if (_orderService == null)
                _orderService = new OrderService(_storeContext);
            return _orderService;
        }
    }

    private IUserService _userService;
    public IUserService UserService
    {
        get
        {
            if (_userService == null)
                _userService = new UserService(_storeContext, _userManager, _tokenService);
            return _userService;
        }
    }
    private IBasketService _basketService;
    public IBasketService BasketService
    {
        get
        {
            if (_basketService == null)
                _basketService = new BasketService(_storeContext);
            return _basketService;
        }
    }
    private IProductService _productService;
    public IProductService ProductService
    {
        get
        {
            if (_productService == null)
                _productService = new ProductService(_storeContext);
            return _productService;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _storeContext.SaveChangesAsync();
    }

}
