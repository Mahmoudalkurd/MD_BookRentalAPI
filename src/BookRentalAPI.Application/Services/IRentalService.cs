using BookRentalAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookRentalAPI.Application.Services
{
    public interface IRentalService
    {
        Task<IEnumerable<Rental>> GetRentalsByUserIdAsync(int userId);
        Task<Rental> GetRentalByIdAsync(int rentalId);
        Task CreateRentalAsync(Rental rental);
        Task ReturnRentalAsync(int rentalId);
    }
}