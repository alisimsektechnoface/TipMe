using FluentValidation;

namespace Application.Features.InvoiceOptions.Commands.Delete;

public class DeleteInvoiceOptionCommandValidator : AbstractValidator<DeleteInvoiceOptionCommand>
{
    public DeleteInvoiceOptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}