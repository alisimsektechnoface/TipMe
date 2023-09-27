using FluentValidation;

namespace Application.Features.Tips.Commands.Delete;

public class DeleteTipCommandValidator : AbstractValidator<DeleteTipCommand>
{
    public DeleteTipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}