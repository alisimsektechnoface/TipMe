using FluentValidation;

namespace Application.Features.Contracts.Commands.Create;

public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
{
    public CreateContractCommandValidator()
    {
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}