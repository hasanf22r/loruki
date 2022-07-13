using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}