using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure;
public class BasketService: IBasketService
{
    private readonly StoreContext _storeContext;

    public BasketService(StoreContext storeContext)
    {
        _storeContext = storeContext;
    }
}
