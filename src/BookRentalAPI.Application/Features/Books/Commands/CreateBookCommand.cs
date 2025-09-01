using BookRentalAPI.Domain.Entities;      // For Book, User, etc.
using BookRentalAPI.Domain.Common;        // For OperationResult
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BookRentalAPI.Domain.Interfaces; 

namespace BookRentalAPI.Application.Features.Books.Commands
{
    public class CreateBookCommand : IRequest<Result<Book>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Result<Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Description = request.Description,
                PublishedDate = request.PublishedDate
            };

            await _bookRepository.AddAsync(book);

            return new Result<Book>
            {
                Success = true,
                Data = book
            };
        }
    }
}