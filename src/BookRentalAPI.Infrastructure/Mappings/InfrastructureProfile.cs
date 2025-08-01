using AutoMapper;
using BookRentalAPI.Domain.Entities;
using BookRentalAPI.Infrastructure.DTOs;

namespace BookRentalAPI.Infrastructure.Mappings
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<User, UserDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Rental, RentalDto>();
        }
    }
}
