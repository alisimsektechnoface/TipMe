using FluentValidation;

namespace Application.Features.Invoices.Commands.Update;

public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
{
    public UpdateInvoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.InvoiceDate).NotEmpty();
        RuleFor(c => c.StoreId).NotEmpty();
        RuleFor(c => c.WaiterId).NotEmpty();
    }
}