using BookRentalAPI.Domain.Entities;

namespace BookRentalAPI.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        // Add custom methods for Rental if needed
    }
}