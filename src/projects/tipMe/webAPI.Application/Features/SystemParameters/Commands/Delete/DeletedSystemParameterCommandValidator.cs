using FluentValidation;

namespace Application.Features.SystemParameters.Commands.Delete;

public class DeleteSystemParameterCommandValidator : AbstractValidator<DeleteSystemParameterCommand>
{
    public DeleteSystemParameterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}