using FluentValidation;

namespace Application.Features.Invoices.Commands.Create;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(c => c.InvoiceDate).NotEmpty();
        RuleFor(c => c.StoreId).NotEmpty();
        RuleFor(c => c.WaiterId).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
        RuleFor(c => c.TipDate).NotEmpty();
        RuleFor(c => c.IsTipped).NotEmpty();
        RuleFor(c => c.QrCode).NotEmpty();
        RuleFor(c => c.Currency).NotEmpty();
    }
}