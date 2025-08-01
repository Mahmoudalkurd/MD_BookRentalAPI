using BookRentalAPI.Domain.Entities;
using MediatR;

namespace BookRentalAPI.Application.Features.Books.Commands
{
    public class UpdateBookCommand : IRequest<OperationResult<Book>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
