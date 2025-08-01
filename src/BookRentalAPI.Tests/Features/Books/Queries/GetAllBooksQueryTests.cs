using BookRentalAPI.Application.Features.Books.Queries;
using BookRentalAPI.Domain.Entities;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace BookRentalAPI.Tests.Features.Books.Queries
{
    public class GetAllBooksQueryTests : TestBase
    {
        [Fact]
        public async Task Handle_ReturnsAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1" },
                new Book { Id = 2, Title = "Book 2" }
            };

            _mockBookRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(books);

            var handler = new GetAllBooksQueryHandler(_mockBookRepository.Object);

            // Act
            var result = await handler.Handle(new GetAllBooksQuery(), CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(2, result.Data.Count());
        }

        [Fact]
        public async Task Handle_NoBooks_ReturnsEmptyList()
        {
            // Arrange
            _mockBookRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Book>());

            var handler = new GetAllBooksQueryHandler(_mockBookRepository.Object);

            // Act
            var result = await handler.Handle(new GetAllBooksQuery(), CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Empty(result.Data);
        }
    }
}
