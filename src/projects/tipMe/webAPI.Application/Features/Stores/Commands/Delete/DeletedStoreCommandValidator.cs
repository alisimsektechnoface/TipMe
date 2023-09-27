using FluentValidation;

namespace Application.Features.Stores.Commands.Delete;

public class DeleteStoreCommandValidator : AbstractValidator<DeleteStoreCommand>
{
    public DeleteStoreCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}