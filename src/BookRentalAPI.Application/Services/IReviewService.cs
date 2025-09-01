using BookRentalAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookRentalAPI.Application.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviewsByBookIdAsync(int bookId);
        Task<Review> GetReviewByIdAsync(int reviewId);
        Task AddReviewAsync(Review review);
        Task DeleteReviewAsync(int reviewId);
    }
}