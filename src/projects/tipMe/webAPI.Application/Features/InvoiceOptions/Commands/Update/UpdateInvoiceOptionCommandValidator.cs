using FluentValidation;

namespace Application.Features.InvoiceOptions.Commands.Update;

public class UpdateInvoiceOptionCommandValidator : AbstractValidator<UpdateInvoiceOptionCommand>
{
    public UpdateInvoiceOptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.InvoiceId).NotEmpty();
        RuleFor(c => c.OptionId).NotEmpty();
    }
}