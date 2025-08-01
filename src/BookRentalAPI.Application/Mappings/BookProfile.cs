using AutoMapper;
using BookRentalAPI.Application.Features.Books.Commands;
using BookRentalAPI.Domain.Entities;

namespace BookRentalAPI.Application.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}
