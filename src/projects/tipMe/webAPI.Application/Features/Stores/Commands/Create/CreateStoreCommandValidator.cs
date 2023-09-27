using FluentValidation;

namespace Application.Features.Stores.Commands.Create;

public class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
{
    public CreateStoreCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}