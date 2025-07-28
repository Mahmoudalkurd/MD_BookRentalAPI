using BookRentalAPI.Domain.Entities;
using MediatR;

namespace BookRentalAPI.Application.Features.Books.Queries
{
    public class GetBookByIdQuery : IRequest<OperationResult<Book>>
    {
        public int Id { get; set; }
    }
}