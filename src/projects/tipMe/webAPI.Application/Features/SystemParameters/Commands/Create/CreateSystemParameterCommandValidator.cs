using FluentValidation;

namespace Application.Features.SystemParameters.Commands.Create;

public class CreateSystemParameterCommandValidator : AbstractValidator<CreateSystemParameterCommand>
{
    public CreateSystemParameterCommandValidator()
    {
        RuleFor(c => c.ParameterKey).NotEmpty();
        RuleFor(c => c.ParameterValue).NotEmpty();
        RuleFor(c => c.SampleValue).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}