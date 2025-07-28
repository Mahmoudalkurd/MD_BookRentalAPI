using BookRentalAPI.Application.Features.Books.Queries;
using BookRentalAPI.Domain.Entities;
using BookRentalAPI.Infrastructure.Data;
using BookRentalAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BookRentalAPI.Tests.Features.Books.Queries
{
    public class GetBookByIdQueryTests
    {
        private readonly Mock<IRepository<Book>> _mockRepo;
        private readonly GetBookByIdQueryHandler _handler;

        public GetBookByIdQueryTests()
        {
            _mockRepo = new Mock<IRepository<Book>>();
            _handler = new GetBookByIdQueryHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ValidId_ReturnsBook()
        {
            // Arrange
            var bookId = 1;
            var book = new Book { Id = bookId, Title = "Test Book" };
            
            _mockRepo.Setup(x => x.GetByIdAsync(bookId))
                .ReturnsAsync(book);

            var query = new GetBookByIdQuery { Id = bookId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(bookId, result.Data.Id);
        }

        [Fact]
        public async Task Handle_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var bookId = 999;
            
            _mockRepo.Setup(x => x.GetByIdAsync(bookId))
                .ReturnsAsync((Book)null);

            var query = new GetBookByIdQuery { Id = bookId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(404, result.StatusCode);
        }
    }
}