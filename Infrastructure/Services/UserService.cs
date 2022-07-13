using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class UserService: IUserService 
{
    private readonly StoreContext _storeContext;
    private readonly UserManager<User> _userManager;
    private readonly ITokenService tokenService;

    public UserService(StoreContext storeContext, UserManager<User> userManager, ITokenService tokenService)
    {
        _storeContext = storeContext;
        _userManager = userManager;
        this.tokenService = tokenService;
    }


    public async Task<IdentityResult> CreateAsync(User user, string pass)
    {
        return await _userManager.CreateAsync(user, pass);
    }



    public async Task<string> CheckPasswordAsync(string email, string pass)
    {   
        User user = await _userManager.FindByEmailAsync(email);
        var res = await _userManager.CheckPasswordAsync(user, pass);

        string token = string.Empty;
        
        if (res)
            token = await tokenService.GenerateToken(user);

        return token; 
    }

    public async Task<IReadOnlyList<User>> GetAllUser()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        return await _userManager.Users.FirstOrDefaultAsync(f=>f.Id==id);
    }
}
