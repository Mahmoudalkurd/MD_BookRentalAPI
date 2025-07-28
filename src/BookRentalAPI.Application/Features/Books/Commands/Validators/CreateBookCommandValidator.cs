using FluentValidation;
using BookRentalAPI.Application.Features.Books.Commands;

namespace BookRentalAPI.Application.Features.Books.Commands.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(100).WithMessage("Author must not exceed 100 characters");

            RuleFor(x => x.PublishedDate)
                .NotEmpty().WithMessage("Published date is required")
                .LessThan(DateTime.Now).WithMessage("Published date cannot be in the future");
        }
    }
}