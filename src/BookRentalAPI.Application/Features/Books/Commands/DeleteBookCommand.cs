using BookRentalAPI.Domain.Common;
using MediatR;

namespace BookRentalAPI.Application.Features.Books.Commands
{
    public class DeleteBookCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
