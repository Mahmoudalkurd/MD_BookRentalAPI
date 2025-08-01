using BookRentalAPI.Application.Features.Books.Commands;
using BookRentalAPI.Domain.Entities;
using Moq;
using Xunit;

namespace BookRentalAPI.Tests.Features.Books.Commands
{
    public class CreateBookCommandTests : TestBase
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsCreatedBook()
        {
            // Arrange
            var command = new CreateBookCommand
            {
                Title = "Test Book",
                Author = "Test Author",
                Description = "Test Description",
                PublishedDate = DateTime.Now.AddYears(-1)
            };

            var handler = new CreateBookCommandHandler(_mockBookRepository.Object);

            _mockBookRepository.Setup(x => x.AddAsync(It.IsAny<Book>()))
                .Returns(Task.CompletedTask)
                .Callback<Book>(b => b.Id = 1);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(1, result.Data.Id);
            Assert.Equal(command.Title, result.Data.Title);
        }

        [Fact]
        public async Task Handle_InvalidRequest_ReturnsValidationErrors()
        {
            // Arrange
            var command = new CreateBookCommand(); // Invalid - missing required fields
            var validator = new CreateBookCommandValidator();

            // Act
            var validationResult = await validator.ValidateAsync(command);

            // Assert
            Assert.False(validationResult.IsValid);
            Assert.Contains(validationResult.Errors, e => e.PropertyName == "Title");
            Assert.Contains(validationResult.Errors, e => e.PropertyName == "Author");
        }
    }
}
