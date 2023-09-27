using FluentValidation;

namespace Application.Features.Waiters.Commands.Delete;

public class DeleteWaiterCommandValidator : AbstractValidator<DeleteWaiterCommand>
{
    public DeleteWaiterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}