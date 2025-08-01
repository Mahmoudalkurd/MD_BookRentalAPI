using BookRentalAPI.Domain.Entities;
using BookRentalAPI.Domain.Interfaces;
using BookRentalAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookRentalAPI.Infrastructure.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(BookRentalDbContext context) : base(context) { }

        public async Task<IEnumerable<Rental>> GetActiveRentalsByUserAsync(int userId)
        {
            return await _context.Rentals
                .Where(r => r.UserId == userId && r.ActualReturnDate == null)
                .ToListAsync();
        }
    }
}
