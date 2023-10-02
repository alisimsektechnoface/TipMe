using FluentValidation;

namespace Application.Features.Tips.Commands.SavePayment;

public class SavePaymentCommandValidator : AbstractValidator<SavePaymentCommand>
{
    public SavePaymentCommandValidator() { }
}