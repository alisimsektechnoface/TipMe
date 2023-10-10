using FluentValidation;

namespace Application.Features.SystemParameters.Commands.Update;

public class UpdateSystemParameterCommandValidator : AbstractValidator<UpdateSystemParameterCommand>
{
    public UpdateSystemParameterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ParameterKey).NotEmpty();
        RuleFor(c => c.ParameterValue).NotEmpty();
        RuleFor(c => c.SampleValue).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}