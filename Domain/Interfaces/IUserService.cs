using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces;
public interface IUserService
{
    Task<IdentityResult> CreateAsync(User user, string pass);
    Task<IReadOnlyList<User>> GetAllUser();
    Task<User> GetUser(int id);
    Task<string> CheckPasswordAsync(string email, string pass);
 
}
