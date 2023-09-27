using FluentValidation;

namespace Application.Features.Invoices.Commands.Delete;

public class DeleteInvoiceCommandValidator : AbstractValidator<DeleteInvoiceCommand>
{
    public DeleteInvoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}