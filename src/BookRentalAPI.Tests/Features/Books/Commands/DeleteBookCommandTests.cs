using BookRentalAPI.Application.Features.Books.Commands;
using BookRentalAPI.Domain.Entities;
using Moq;
using Xunit;

namespace BookRentalAPI.Tests.Features.Books.Commands
{
    public class DeleteBookCommandTests : TestBase
    {
        [Fact]
        public async Task Handle_ExistingBook_DeletesBook()
        {
            // Arrange
            var existingBook = new Book { Id = 1 };
            _mockBookRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(existingBook);

            var handler = new DeleteBookCommandHandler(_mockBookRepository.Object);

            // Act
            var result = await handler.Handle(new DeleteBookCommand { Id = 1 }, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            _mockBookRepository.Verify(x => x.DeleteAsync(existingBook), Times.Once);
        }

        [Fact]
        public async Task Handle_NonExistingBook_ReturnsNotFound()
        {
            // Arrange
            _mockBookRepository.Setup(x => x.GetByIdAsync(999))
                .ReturnsAsync((Book)null);

            var handler = new DeleteBookCommandHandler(_mockBookRepository.Object);

            // Act
            var result = await handler.Handle(new DeleteBookCommand { Id = 999 }, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(404, result.StatusCode);
        }
    }
}
