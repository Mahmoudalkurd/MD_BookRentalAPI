using FluentValidation;
using BookRentalAPI.Application.Features.Books.Queries;

namespace BookRentalAPI.Application.Features.Books.Queries.Validators
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
