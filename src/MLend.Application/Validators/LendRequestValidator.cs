using FluentValidation;

namespace MLend.Application;

public class LendRequestValidator: AbstractValidator<LendRequest> 
{
    public LendRequestValidator()
    {
        RuleFor(x => x.BookId)
            .NotEmpty()
            .NotNull()
            .WithMessage("BookId inválido");

        RuleFor(x => x.Document)
            .NotEmpty()
            .NotNull()
            .Length(11, 11)
            .WithMessage("Document inválido");
    }
}