using FluentValidation;

namespace Application.Features.Waiters.Commands.Create;

public class CreateWaiterCommandValidator : AbstractValidator<CreateWaiterCommand>
{
    public CreateWaiterCommandValidator()
    {
        RuleFor(c => c.StoreId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}