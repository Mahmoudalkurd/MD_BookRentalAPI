using BookRentalAPI.Application.Features.Books.Commands;
using BookRentalAPI.Domain.Entities;
using Moq;
using Xunit;

namespace BookRentalAPI.Tests.Features.Books.Commands
{
    public class UpdateBookCommandTests : TestBase
    {
        [Fact]
        public async Task Handle_ValidRequest_UpdatesBook()
        {
            // Arrange
            var existingBook = new Book
            {
                Id = 1,
                Title = "Old Title",
                Author = "Old Author",
                Description = "Old Description",
                PublishedDate = DateTime.Now.AddYears(-2)
            };

            var command = new UpdateBookCommand
            {
                Id = 1,
                Title = "New Title",
                Author = "New Author",
                Description = "New Description",
                PublishedDate = DateTime.Now.AddYears(-1)
            };

            _mockBookRepository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(existingBook);

            var handler = new UpdateBookCommandHandler(_mockBookRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(command.Title, result.Data.Title);
            Assert.Equal(command.Author, result.Data.Author);
            _mockBookRepository.Verify(x => x.UpdateAsync(It.IsAny<Book>()), Times.Once);
        }

        [Fact]
        public async Task Handle_NonExistingBook_ReturnsNotFound()
        {
            // Arrange
            var command = new UpdateBookCommand { Id = 999 };
            _mockBookRepository.Setup(x => x.GetByIdAsync(999))
                .ReturnsAsync((Book)null);

            var handler = new UpdateBookCommandHandler(_mockBookRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(404, result.StatusCode);
        }
    }
}
