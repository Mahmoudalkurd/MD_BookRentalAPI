using BookRentalAPI.Domain.Entities;
using BookRentalAPI.Domain.Interfaces;
using BookRentalAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookRentalAPI.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly BookRentalDbContext _context;

        public BookService(BookRentalDbContext context)
        {
            _context = context;
        }

        public async Task<double?> GetAverageRatingAsync(int bookId)
        {
            return await _context.Reviews
                .Where(r => r.BookId == bookId)
                .AverageAsync(r => (double?)r.Rating);
        }

        public async Task UpdateBookAvailability(int bookId, bool isAvailable)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.IsAvailable = isAvailable;
                await _context.SaveChangesAsync();
            }
        }
    }
}
