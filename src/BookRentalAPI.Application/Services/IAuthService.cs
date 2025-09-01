using BookRentalAPI.Domain.Entities;
using System.Threading.Tasks;

namespace BookRentalAPI.Application.Services
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string email, string password);
        Task<User> RegisterAsync(User user, string password);
        Task<bool> IsEmailConfirmedAsync(int userId);
    }
}