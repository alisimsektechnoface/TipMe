using FluentValidation;

namespace Application.Features.Invoices.Commands.Create;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        //RuleFor(c => c.StoreId).NotEmpty();
        RuleFor(c => c.WaiterId).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
    }
}