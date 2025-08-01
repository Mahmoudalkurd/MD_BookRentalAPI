using BookRentalAPI.Domain.Entities;
using BookRentalAPI.Domain.Interfaces;
using BookRentalAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookRentalAPI.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BookRentalDbContext context) : base(context) { }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
