using BookRentalAPI.Domain.Entities;
using MediatR;

namespace BookRentalAPI.Application.Features.Books.Commands
{
    public class CreateBookCommand : IRequest<OperationResult<Book>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}