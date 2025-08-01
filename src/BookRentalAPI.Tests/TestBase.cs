using BookRentalAPI.Infrastructure.Data;
using BookRentalAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BookRentalAPI.Tests
{
    public abstract class TestBase
    {
        protected Mock<IRepository<Book>> _mockBookRepository;
        protected BookRentalDbContext _dbContext;

        protected TestBase()
        {
            // Setup mock repository
            _mockBookRepository = new Mock<IRepository<Book>>();

            // Setup in-memory database
            var options = new DbContextOptionsBuilder<BookRentalDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new BookRentalDbContext(options);
        }
    }
}
