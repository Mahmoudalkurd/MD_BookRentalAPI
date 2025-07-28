using BookRentalAPI.Domain.Entities;
using BookRentalAPI.Domain.Interfaces;
using BookRentalAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookRentalAPI.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookRentalDbContext context) : base(context) { }

        public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
        {
            return await _context.Books
                .Where(b => b.IsAvailable)
                .ToListAsync();
        }

        public async Task<double?> GetAverageRatingAsync(int bookId)
        {
            return await _context.Reviews
                .Where(r => r.BookId == bookId)
                .AverageAsync(r => (double?)r.Rating);
        }
    }
}