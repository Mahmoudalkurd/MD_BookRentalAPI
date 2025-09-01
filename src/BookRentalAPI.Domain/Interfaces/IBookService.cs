using System.Threading.Tasks;

namespace BookRentalAPI.Domain.Interfaces
{
    public interface IBookService
    {
        Task<double?> GetAverageRatingAsync(int bookId);
        Task UpdateBookAvailability(int bookId, bool isAvailable);
    }
}