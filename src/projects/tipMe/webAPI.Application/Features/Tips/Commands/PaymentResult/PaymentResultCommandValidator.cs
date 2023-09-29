using FluentValidation;

namespace Application.Features.Tips.Commands.PaymentResult;

public class PaymentResultCommandValidator : AbstractValidator<PaymentResultCommand>
{
    public PaymentResultCommandValidator() { }
}