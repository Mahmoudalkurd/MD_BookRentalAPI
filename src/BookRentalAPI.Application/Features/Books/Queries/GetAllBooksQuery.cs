using BookRentalAPI.Domain.Entities;
using MediatR;

namespace BookRentalAPI.Application.Features.Books.Queries
{
    public class GetAllBooksQuery : IRequest<OperationResult<List<Book>>>
    {
        public string Filter { get; set; }
        public string Sort { get; set; } = "asc";
    }
}
