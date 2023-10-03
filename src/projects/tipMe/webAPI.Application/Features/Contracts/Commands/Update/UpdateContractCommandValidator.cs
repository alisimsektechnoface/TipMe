using FluentValidation;

namespace Application.Features.Contracts.Commands.Update;

public class UpdateContractCommandValidator : AbstractValidator<UpdateContractCommand>
{
    public UpdateContractCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}