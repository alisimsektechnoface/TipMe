using FluentValidation;

namespace Application.Features.InvoiceOptions.Commands.Create;

public class CreateInvoiceOptionCommandValidator : AbstractValidator<CreateInvoiceOptionCommand>
{
    public CreateInvoiceOptionCommandValidator()
    {
        RuleFor(c => c.InvoiceId).NotEmpty();
        RuleFor(c => c.OptionId).NotEmpty();
    }
}