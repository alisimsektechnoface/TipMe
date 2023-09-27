using FluentValidation;

namespace Application.Features.Waiters.Commands.Update;

public class UpdateWaiterCommandValidator : AbstractValidator<UpdateWaiterCommand>
{
    public UpdateWaiterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StoreId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
    }
}